namespace FinalFantasyTryoutGoesWeb.Application
{
    using System.Reflection;
    using AutoMapper;
    using global::Domain.Entities.Common;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

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
