using Crosscutting.Configuracoes;
using Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILoja.Configuracao
{
    public static class DataBaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appConnection1 = configuration.GetConnectionString("DefaultConnection");
            var appConnection = configuration.GetSection("ConnectionString").GetChildren().FirstOrDefault();


            //var connection = appConnection.Get<ConnectionStrings>();
            var connection = appConnection;

            services.AddDbContext<ProjetoBaseDbContext>(options =>
            {
                options.UseSqlServer(connection.Key, options => options.CommandTimeout(99999))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                // options.UseSqlServer("Server=localhost;Database=LojaVirtual;User Id=sa;Password=cep31573420;", sqlOptions => sqlOptions.CommandTimeout(99999)
                //).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            return services;
        }
    }
}
