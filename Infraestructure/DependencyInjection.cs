using Domian.Port;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurateCosmosDB>(option =>
            {

                option.ConnectionString = configuration[$"{nameof(ConfigurateCosmosDB)}:{nameof(option.ConnectionString)}"];
                option.DatabaseName = configuration[$"{nameof(ConfigurateCosmosDB)}:{nameof(option.DatabaseName)}"];
            });

            services.AddSingleton<IConfigurateCosmosDB>(sp => sp.GetRequiredService<IOptions<ConfigurateCosmosDB>>().Value);
            services.AddScoped<IMainContextCosmos, MainContextCosmosDB>();

            services.AddScoped(typeof(IEstudianteRepository), typeof(EstudianteRepository));

            return services;
        }
    }
}
