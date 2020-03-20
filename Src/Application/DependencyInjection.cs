namespace FinalFantasyTryoutGoesWeb.Application
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public class DependencyInjection
    {
        public static IServiceCollection AddApplication(IServiceCollection services) 
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
