using System.Text.RegularExpressions;

namespace AutoGlass.Products.Application.Validators
{
    public class ProductDtoValidation : ProductDtoValidate
    {
        public ProductDtoValidation()
        {
            RuleSet(ProductDtoValidationRuleConstants.AddRule, () =>
            {
                ValidateDescription();
                ValidateDataFabricacao();
                ValidateCNPJFornecedor();
            });
            RuleSet(ProductDtoValidationRuleConstants.UpdateRule, () =>
            {
                ValidateDescription();
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
