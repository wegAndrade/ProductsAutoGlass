using AutoGlass.Products.Application.Entities;
using AutoGlass.Products.Application.Validators;
using AutoGlass.Products.Domain.Dto_s;
using AutoGlass.Products.Domain.Entities;
using AutoGlass.Products.Domain.Interfaces.Repository;
using AutoGlass.Products.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation;

namespace AutoGlass.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductDtoValidation _validator;
        private readonly NotificationContext _notificationContext;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, ProductDtoValidation validator, NotificationContext notificationContext, IProductRepository productRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _notificationContext = notificationContext;
            _productRepository = productRepository;

        }

        public async Task<int> Add(ProductDto productDto)
        {
            var validationResult = _validator.Validate(productDto, opt => opt.IncludeRuleSets(ProductDtoValidationRuleConstants.AddRule));

            if (!validationResult.IsValid)
            {
                _notificationContext.AddNotifications(validationResult);
                return 0;

            }
            Product product = _mapper.Map<Product>(productDto);
            product.Situacao = true;

            await _productRepository.Add(product);

            return product.CodigoProduto;
        }

        public async Task Delete(int productId)
        {
            var product = await _productRepository.GetById(productId);
            if (product is null)
            {
                _notificationContext.AddNotification(new Notification("NotFound", $"Produto com Id {productId} não encontrado"));
                return;
            }

            product.Situacao = false;

            await _productRepository.Update(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
       => await _productRepository.GetAll();

        public async Task<Product?> GetById(int id)
            => await _productRepository.GetById(id);

        public async Task Update(ProductDto productDto, int productId)
        {
            var validationResult = _validator.Validate(productDto, opt => opt.IncludeRuleSets(ProductDtoValidationRuleConstants.UpdateRule));

            if (!validationResult.IsValid)
            {
                _notificationContext.AddNotifications(validationResult);
                return;

            }

            var product = await _productRepository.GetById(productId);
            if (product is null)
            {
                _notificationContext.AddNotification(new Notification("NotFound", $"Produto com Id {productId} não encontrado"));
                return;
            }

            product = _mapper.Map<Product>(productDto);
            product.CodigoProduto = productId;
            product.Situacao = true;
            await _productRepository.Update(product);
        }
    }
}
