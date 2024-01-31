using AutoGlass.Products.Domain.Dto_s;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AutoGlass.Products.Application.Validators
{
    public class ProductDtoValidate : AbstractValidator<ProductDto>
    {

        protected void ValidateDataFabricacao()
            => RuleFor(p => p)
            .Must(HaveDataFabricacaoNotGreaterThanDataValidade)
            .WithMessage("Data de Fabricação deve ser menor que a data de validade");

        protected void ValidateCNPJFornecedor() => RuleFor(p => p.cnpjForncedor)
            .Must((dto, cnpj) => ValidarCNPJ(cnpj));
         
        protected static bool HaveDataFabricacaoNotGreaterThanDataValidade(ProductDto dto)
            => DateTime.Compare(dto.dataFabricacao, dto.dataValidade) <= 0;
        private static bool ValidarCNPJ(string cnpj)
        {
            if (cnpj.Length != 14) // CNPJ tem 14 dígitos
                return false;

            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }



        public ProductDtoValidate()
        {
        }
    }

}
