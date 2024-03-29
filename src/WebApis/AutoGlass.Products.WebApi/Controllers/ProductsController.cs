﻿using AutoGlass.Products.Domain.Dto_s;
using AutoGlass.Products.Domain.Entities;
using AutoGlass.Products.Domain.Interfaces.Services;
using AutoGlass.Products.WebApi.Extensions;
using AutoGlass.Products.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.Products.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageQuery paginationQuery)
        {
            try
            {
                
                var products = await _productService.GetAll();

                if(products is null || !products.Any())
                {
                    return NoContent();
                }
                var response =  PagedResponseExtensions.GetPagedListAsync<Product>(products.AsQueryable(), paginationQuery);
                return Ok(response);
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
               var productId = await _productService.Add(product);

                return Created($"api/Products/{productId}", new { });
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

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] int productId)
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
