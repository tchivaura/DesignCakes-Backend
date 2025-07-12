using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DesignCakesApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DesignCakesApp.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DesignCakesDb");
            services.AddDbContext<DesignCakesDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("DesignCakesApp.Infrastructure");
                }


                    );


            });
            return services;
        }
    }
}
