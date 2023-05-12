using Business_Layer.Dto;
using Business_Layer.Factories;
using Data_Layer.Entity;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;


namespace Crud_Product_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
       
        private readonly IProductServiceFactory _productServiceFactory;


        private ILog _ILog;

        public ProductController(IProductServiceFactory productServiceFactory)
        {
            _productServiceFactory = productServiceFactory;
            _ILog = Log.GetInstance;
        }
        [Route("productResult")]
        [HttpGet]
        public async Task<ActionResult<PagedResult<Product>>> GetProducts(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var productService = _productServiceFactory.Create();
                var products = await productService.GetProductAsync(pageNumber, pageSize);
                return products;
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                var productService = _productServiceFactory.Create();
                var product = await productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }


                return Ok(product);
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProductAsync(ProductDto productDto)
        {
            try
            {
                var productService = _productServiceFactory.Create();
                var product = productDto.MapToProduct();
                await productService.AddProduct(productDto);
                var createdProductDto = product.MapToProductDto();
                return CreatedAtAction(nameof(GetProducts), new { id = createdProductDto.Id }, createdProductDto);//
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(int id, ProductDto productDto)
        {
            try
            {
                if (id != productDto.Id)
                {
                    return BadRequest();
                }
                var productService = _productServiceFactory.Create();
                var product = productDto.MapToProduct();
                var updatedProduct = await productService.UpdateProduct(productDto);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }



        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var productService = _productServiceFactory.Create();
                var product = await productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                await productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [Route("searchPage")]
        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductDto>>> SearchProducts([FromQuery] string title, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var productService = _productServiceFactory.Create();
                var pagedProducts = await productService.GetPagedProductAsync(title, pageNumber, pageSize);
                return Ok(pagedProducts);   
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
