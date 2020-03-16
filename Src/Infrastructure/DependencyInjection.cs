namespace Infrastructure
{
    using global::Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConnection connection) 
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection.String));

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<FFDbContext>();

            return services;
        }
    }
}
