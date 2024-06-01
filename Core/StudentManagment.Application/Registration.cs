using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StudentManagment.Application;
public static class Registration
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		return services;
	}
}
