using AutoGlass.Products.Application.Validators;
using AutoGlass.Products.Domain.Dto_s;
using FluentValidation;

namespace AutoGlass.Products.Tests.Application
{
    public  class ProductValidatorTests
    {
        [Fact]
        public void ShoudbeInvalidWhenDataFabricacaoMaiorQueDataValidadeOnAddRule()
        {
            var productDTO = new ProductDto("Teste",true,DateTime.Now.AddDays(2), DateTime.Now, 2, "15395626000111");
            var validator = new ProductDtoValidation();
            var result = validator.Validate(productDTO, opt => opt.IncludeRuleSets(ProductDtoValidationRuleConstants.AddRule));
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
        [Fact]
        public void ShoudbeInvalidWhenDataFabricacaoMaiorQueDataValidadeOnUpdateRule()
        {
            var productDTO = new ProductDto("Teste", true, DateTime.Now.AddDays(2), DateTime.Now, 2, "15395626000111");
            var validator = new ProductDtoValidation();
            var result = validator.Validate(productDTO, opt => opt.IncludeRuleSets(ProductDtoValidationRuleConstants.UpdateRule));
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
        [Fact]
        public void ShoudbeInvalidWhenCNPJForncedorInvalidoOnAddRule()
        {
            var productDTO = new ProductDto("Teste", true, DateTime.Now.AddDays(-2), DateTime.Now, 2, "15395626100011");
            var validator = new ProductDtoValidation();
            var result = validator.Validate(productDTO, opt => opt.IncludeRuleSets(ProductDtoValidationRuleConstants.AddRule));
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShoudbeInvalidWhenCNPJForncedorInvalidoOnUpdateRule()
        {
            var productDTO = new ProductDto("Teste", true, DateTime.Now.AddDays(-2), DateTime.Now, 2, "123123123123");
            var validator = new ProductDtoValidation();
            var result = validator.Validate(productDTO, opt => opt.IncludeRuleSets(ProductDtoValidationRuleConstants.AddRule));
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
