using DesignCakesApp.Application;
using DesignCakesApp.Infrastructure;

namespace DesignCakesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AppDI(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationDI().AddInfrastructureDI(configuration);
            return services;
        }
    }
}
