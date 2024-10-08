using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using sportify.Datalayer.Repository;
using Produktet = sportify.core.cs.Products;


namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;

        }


        [HttpGet("Get-All-Products") ]

        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            try
            {
                var produktet = await  _products.GetProducts();

                return Ok(produktet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get-Product-byid")]
        public async Task<ActionResult<List<ProductDto>>> GetProductbyid(Guid id)
        {
            try
            {
                var produktet = await _products.GetProductById(id);

                return Ok(produktet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("Create-Products")]
        public async Task<ActionResult<List<Produktet>>> CreateProduct([FromBody] ProductDto produktet)
        {
            try
            {
                var Respoyunse = await _products.CreateProduct(produktet);


                return Ok(Respoyunse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("GetFiltered-Products")]
        public async Task<ActionResult<List<Produktet>>> FilterProducts([FromBody] FilterProductsDto products)
        {
            try
            {
                var filteredList = await _products.FilterProducts(products);

                return Ok(filteredList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
