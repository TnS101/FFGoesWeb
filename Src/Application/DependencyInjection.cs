﻿namespace FinalFantasyTryoutGoesWeb.Application
{
    using AutoMapper;
    using global::Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public class DependencyInjection
    {
        public static IServiceCollection AddApplication(IServiceCollection services) 
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(EquipmentHandler));
            services.AddScoped(typeof(BattleHandler));
            services.AddScoped(typeof(GeneratorHandler));
            services.AddScoped(typeof(ValidatorHandler));
            services.AddScoped(typeof(SignInManager<ApplicationUser>));
            services.AddScoped(typeof(UserManager<ApplicationUser>));

            return services;
        }
    }
}
