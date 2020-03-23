namespace FinalFantasyTryoutGoesWeb.Application
{
    using AutoMapper;
    using global::Domain.Entities.Common;
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
