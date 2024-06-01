using StudentManagment.Persistence;
using StudentManagment.AutoMapper;
using StudentManagment.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAutoMapper();
builder.Services.AddSession();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AspNetCore_Auth";
    options.LoginPath = "/Account/SignIn";
    options.AccessDeniedPath = "/Errors/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

using (var scope = app.Services.CreateScope())
{
    await scope.CheckAndCreateRole();
}

app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();


