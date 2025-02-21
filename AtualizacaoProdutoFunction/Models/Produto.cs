using AtualizacaoProdutoFunction.Models.Enum;

namespace AtualizacaoProdutoFunction.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public EStatusProduto Status { get; set; }

        public DateTime DataUltimaVenda { get; set; }
    }
}
