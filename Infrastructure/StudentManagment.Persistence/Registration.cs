using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagment.Application.Interfaces.Repositories;
using StudentManagment.Application.Interfaces.Repositories.Student;
using StudentManagment.Application.Interfaces.UnitOfWorks;
using StudentManagment.Domain.Entities.Identity;
using StudentManagment.Persistence.Context;
using StudentManagment.Persistence.Repositories;
using StudentManagment.Persistence.Repositories.Student;
using StudentManagment.Persistence.UnitOfWorks;

namespace StudentManagment.Persistence;
public static class Registration
{
    public static void AddPersistence(this IServiceCollection services,IConfiguration configuration) 
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddIdentity<AppUser, AppRole>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.User.RequireUniqueEmail = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequiredLength = 1;
        })
         .AddEntityFrameworkStores<AppDbContext>()
         .AddSignInManager<SignInManager<AppUser>>()
         .AddDefaultTokenProviders();

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IStudentReadRepository), typeof(StudentReadRepository));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }


    public async static Task CheckAndCreateRole(this IServiceScope serviceScope)
    {
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        var roles = new[] { "Admin", "Teacher" , "Student" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new AppRole() { Name = role });
        }

        var adminRole = await roleManager.FindByNameAsync("Admin");
        if (!await userManager.CheckByRole(adminRole!, appDbContext))
        {
            AppUser userAdmin = new()
            {
                UserName = "admin123",
                Email = "admin.hyper@gmail.com",
                PhoneNumber = "123789",
            };
            var result = await userManager.CreateAsync(userAdmin, "admin123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(userAdmin, adminRole!.Name!);
            }
        }
    }


    private async static Task<bool> CheckByRole(this UserManager<AppUser> userManager, AppRole role, AppDbContext appDbContext)
    {

        var adminUser = await userManager.GetUsersInRoleAsync("Admin");
        if (adminUser.Any()) { return true; }
        return false;
    }


}
