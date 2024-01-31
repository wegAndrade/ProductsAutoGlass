namespace AutoGlass.Products.Domain.Dto_s
{
    public record ProductDto(string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string cnpjForncedor);

}
