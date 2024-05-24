using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StudentManagment.AutoMapper.Mapper;

namespace StudentManagment.AutoMapper;
public static class Registration
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperProfile());
        });
        services.AddSingleton(mapperConfiguration.CreateMapper());
    }
}
