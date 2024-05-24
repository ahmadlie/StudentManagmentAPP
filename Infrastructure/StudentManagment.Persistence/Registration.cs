using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagment.Application.Interfaces.Repositories;
using StudentManagment.Application.Interfaces.UnitOfWorks;
using StudentManagment.Domain.Entities.Identity;
using StudentManagment.Persistence.Context;
using StudentManagment.Persistence.Repositories;
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
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }
}
