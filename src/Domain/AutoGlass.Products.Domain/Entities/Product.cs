namespace AutoGlass.Products.Domain.Entities
{
    public class Product
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }= string.Empty;

        public Product(int codigoProduto, string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string cNPJFornecedor)
        {
            CodigoProduto = codigoProduto;
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            CNPJFornecedor = cNPJFornecedor;
        }

        public Product()
        {
        }
    }
}
