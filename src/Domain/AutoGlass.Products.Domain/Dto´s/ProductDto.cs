namespace AutoGlass.Products.Domain.Dto_s
{
    public record ProductDto(string descricao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string CNPJFornecedor);

}
