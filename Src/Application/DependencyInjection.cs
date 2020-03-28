namespace Application
{
    using System.Reflection;
    using AutoMapper;
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
