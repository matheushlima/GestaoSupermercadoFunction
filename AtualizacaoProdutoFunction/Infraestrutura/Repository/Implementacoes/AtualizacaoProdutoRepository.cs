using AtualizacaoProdutoFunction.Infraestrutura.Repository.Interface;
using AtualizacaoProdutoFunction.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AtualizacaoProdutoFunction.Infraestrutura.Repository.Implementacoes
{
    internal class AtualizacaoProdutoRepository : IAtualizacaoProdutoRepository
    {
        private readonly IConfiguration _configuration;

        public AtualizacaoProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        }

        private string ObterProdutosSql()
        {
            return @"SELECT ID,
                            QUANTIDADE,
                            STATUS
                       FROM PRODUTOS
                      WHERE DATA_ULTIMA_VENDA <= DATEADD(DAY, -0, GETDATE())";
        }

        private string AtualizarProdutoSql()
        {
            return @"UPDATE PRODUTOS
                        SET STATUS = @Status
                       FROM PRODUTOS
                      WHERE ID = @Id";
        }

        public async Task<List<Produto>> ObterProdutos()
        {
            try
            {
                using var db = GetConnection();

                return (await db.QueryAsync<Produto>(ObterProdutosSql())).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Tuple<bool, string>> AtualizarProduto(Produto produto)
        {
            try
            {
                using var db = GetConnection();

                var sucesso = await db.ExecuteAsync(AtualizarProdutoSql(), produto) > 0;

                if (sucesso)
                    return new Tuple<bool, string>(sucesso, "");

                return new Tuple<bool, string>(sucesso, "Não foi possível atualizar o produto");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
            
        }
    }
}
