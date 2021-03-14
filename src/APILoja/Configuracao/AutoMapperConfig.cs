using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Servicos.AutoMapperConfig;
using Servicos.AutoMapperConfig.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILoja.Configuracao
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperCustomizado(this IServiceCollection servicos)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullDestinationValues = true;
                mc.AddProfile(new PedidoMapper());
                mc.AddProfile(new ProdutoMapper());
                mc.AddProfile(new PromocaoMapper());
                mc.AddProfile(new ClienteMapper());

            });
            var mapper = mappingConfig.CreateMapper();
            servicos.AddSingleton(mapper);
        }
    }
}
