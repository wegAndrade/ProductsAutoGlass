using AutoGlass.Products.Domain.Dto_s;
using AutoGlass.Products.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.Products.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //TODO - Fazer Paginação
                var products = await _productService.GetAll();

                if(products is null || products.Any())
                {
                    return NoContent();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get([FromRoute]int productId)
        {
            try
            {
                var product = await _productService.GetById(productId);

                if (product is null )
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            try
            {
               var codigoProduto = await _productService.Add(product);

                if (product is null)
                {
                    return NotFound();
                }

                return CreatedAtAction(nameof(ProductController.Get),new {productId = codigoProduto });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Put([FromBody] ProductDto product, [FromRoute] int productId)
        {
            try
            {
            await _productService.Update(product, productId);

                if (product is null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{productId}")]
        public async Task<IActionResult> Put([FromRoute] int productId)
        {
            try
            {
                await _productService.Delete(productId);


                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
