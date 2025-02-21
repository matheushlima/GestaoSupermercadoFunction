using AtualizacaoProdutoFunction.Infraestrutura.Repository.Implementacoes;
using AtualizacaoProdutoFunction.Infraestrutura.Repository.Interface;
using AtualizacaoProdutoFunction.Services.Implementacoes;
using AtualizacaoProdutoFunction.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AtualizacaoProdutoFunction.Extension
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServicesServicos(this IServiceCollection services)
        {
            services.AddTransient<IAtualizacaoProdutoService, AtualizacaoProdutoService>();

            return services;
        }

        public static IServiceCollection AddServicesInfraestrutura(this IServiceCollection services)
        {
            services.AddTransient<IAtualizacaoProdutoRepository, AtualizacaoProdutoRepository>();

            return services;
        }
    }
}
