using AtualizacaoProdutoFunction.Models;

namespace AtualizacaoProdutoFunction.Infraestrutura.Repository.Interface
{
    public interface IAtualizacaoProdutoRepository
    {
        Task<List<Produto>> ObterProdutos();

        Task<Tuple<bool, string>> AtualizarProduto(Produto produto);
    }
}
