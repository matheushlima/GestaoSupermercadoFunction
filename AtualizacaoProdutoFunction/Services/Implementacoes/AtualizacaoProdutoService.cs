using AtualizacaoProdutoFunction.Infraestrutura.Repository.Interface;
using AtualizacaoProdutoFunction.Models;
using AtualizacaoProdutoFunction.Models.Enum;
using AtualizacaoProdutoFunction.Services.Interface;
using Microsoft.Extensions.Logging;

namespace AtualizacaoProdutoFunction.Services.Implementacoes
{
    public class AtualizacaoProdutoService : IAtualizacaoProdutoService
    {
        private readonly IAtualizacaoProdutoRepository _atualizacaoProdutoRepository;
        private readonly ILogger _logger;

        public AtualizacaoProdutoService(IAtualizacaoProdutoRepository atualizacaoProdutoRepository, ILoggerFactory logger)
        {
            _atualizacaoProdutoRepository = atualizacaoProdutoRepository;
            _logger = logger.CreateLogger<AtualizacaoProdutoService>();
        }

        public async Task<Tuple<bool, string>> AtualizarStatusProduto()
        {
            try
            {
                var produtos = await _atualizacaoProdutoRepository.ObterProdutos();

                if (produtos.Any())
                {
                    foreach (var produto in produtos)
                    {
                        produto.Status = EStatusProduto.FORA_ESTOQUE;

                        var retorno = await _atualizacaoProdutoRepository.AtualizarProduto(produto);

                        if (retorno.Item1)
                        {
                            _logger.LogInformation($"Produto ID: {produto.Id}, Atualizado!");
                            return retorno;
                        }

                        _logger.LogInformation($"Não foi possível atualizar o produto ID: {produto.Id}!");
                        return retorno;
                    }
                }

                return new Tuple<bool, string>(false, "Não foi encontrado nenhum registro.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}
