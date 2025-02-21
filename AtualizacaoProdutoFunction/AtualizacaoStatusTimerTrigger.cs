using AtualizacaoProdutoFunction.Services.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AtualizacaoProdutoFunction
{
    public class AtualizacaoStatusTimerTrigger
    {
        private readonly ILogger _logger;
        private readonly IAtualizacaoProdutoService _atualizacaoProdutoService;

        public AtualizacaoStatusTimerTrigger(ILoggerFactory loggerFactory, IAtualizacaoProdutoService atualizacaoProdutoService)
        {
            _logger = loggerFactory.CreateLogger<AtualizacaoStatusTimerTrigger>();
            _atualizacaoProdutoService = atualizacaoProdutoService;
        }

        [Function("AtualizacaoProduto")]
        public async Task Run([TimerTrigger("0 0 3 * * *")] TimerInfo myTimer)
        {
            var retorno = await _atualizacaoProdutoService.AtualizarStatusProduto();

            if (retorno.Item1)
                _logger.LogInformation("Rotina executada com sucesso.");
            else
                _logger.LogInformation(retorno.Item2);
        }
    }
}
