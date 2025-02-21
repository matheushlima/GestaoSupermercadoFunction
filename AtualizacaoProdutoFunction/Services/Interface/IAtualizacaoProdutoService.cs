namespace AtualizacaoProdutoFunction.Services.Interface
{
    public interface IAtualizacaoProdutoService
    {
        Task<Tuple<bool, string>> AtualizarStatusProduto();
    }
}
