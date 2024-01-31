using System.Text.RegularExpressions;

namespace AutoGlass.Products.Application.Validators
{
    public class ProductDtoValidation : ProductDtoValidate
    {
        public ProductDtoValidation()
        {
            RuleSet(ProductDtoValidationRuleConstants.AddRule, () =>
            {
                ValidateDataFabricacao();
                ValidateCNPJFornecedor();
            });
            RuleSet(ProductDtoValidationRuleConstants.UpdateRule, () =>
            {
                ValidateDataFabricacao();
                ValidateCNPJFornecedor();
            });
        }
    }


    public static class ProductDtoValidationRuleConstants
    {
        public static string AddRule => "Add";
        public static string UpdateRule => "Update";


    }
}
