using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedProductsController : ControllerBase
    {
        private readonly IBasket _basket;


        public PurchasedProductsController(IBasket basket)
        {
            _basket = basket;

        }

        [HttpGet("Get-all-product-that-arebought")]

        public async Task<ActionResult<List<ProductDto>>> GetAllproducts()
        {
            try
            {
                var product = await _basket.GetAllPurchasedProductsAsync();

                return Ok(product);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpDelete("Delete-Product/{id}"), Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var rez = await _basket.DeleteBoughtProduct(id);
                return Ok(rez);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }





    }
}

