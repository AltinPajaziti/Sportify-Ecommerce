using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasket _basket;


        public BasketController(  IBasket basket)
        {
            _basket = basket;
            
        }

        [HttpPost("Add-Product") ,Authorize ]
        public async Task<IActionResult> AddProduct([FromBody]ProductDto product )
        {
            try
            {
               var rez= await _basket.AddToBasket(product);
                return Ok(rez);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);

                throw;
            }
        }


        [HttpPost("Buy-Product"), Authorize]
        public async Task<IActionResult> BuyProduct([FromBody] ProductDto product)
        {
            try
            {
                var rez = await _basket.BuyProduct(product);
                return Ok(rez);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);

                throw;
            }
        }


        [HttpDelete("Delete-Product/{id}"), Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var rez = await _basket.DeleteProduct(id);
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
