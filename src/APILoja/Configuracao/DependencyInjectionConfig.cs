using Crosscutting.Notificacoes;
using Dados.Contextos;
using Dados.Repositorios;
using Dados.Repositorios.Cadastro;
using Dados.Repositorios.Venda;
using Dados.Uow;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Repositorios.Cadastro;
using Dominio.Interfaces.Repositorios.Venda;
using Dominio.Interfaces.Servicos.Cadastro;
using Dominio.Interfaces.Servicos.Venda;
using Dominio.Interfaces.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Servicos;
using Servicos.Cadastro;
using Servicos.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILoja.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            #region Aplicacao
            services.AddScoped<ProjetoBaseDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Servicos
            services.AddScoped<IPedidoServico, PedidoServico>();
            services.AddScoped<IPedidoItensServico, PedidoItensServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IPromocaoServico, PromocaoServico>();
            services.AddScoped<IClienteServico, ClienteServico>()
                .AddScoped(x => new Lazy<IClienteServico>(()=> x.GetService<IClienteServico>()));
            services.AddScoped<IPedidoFacadeServico, PedidoFacadeServico>();
            //services.AddScoped<IPedidoItensFacadeServico, PedidoItensFacadeServico>();//


            #endregion

            #region Repositorio
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IPedidoItensRepositorio, PedidoItensRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IPromocaoRepositorio, PromocaoRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            #endregion


            return services;
        }
    }
}
