namespace Persistence
{
    using Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class DependencyInjection
    {
        public static IServiceCollection AddApplication(IServiceCollection services, IConnection connection)
        {
            services.AddDbContext<FFDbContext>(options => options.UseSqlServer(connection.String));

            services.AddScoped(provider => provider.GetService<IFFDbContext>());

            return services;
        }
    }
}
