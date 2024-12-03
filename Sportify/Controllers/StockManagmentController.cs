using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.Interfaces;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockManagmentController : ControllerBase
    {

        private readonly IStockManagment _stockManagment;

        public StockManagmentController(IStockManagment stockManagment)
        {
            _stockManagment = stockManagment;
        }


        [HttpGet("Get-all-products-with-stock")]

        public async Task<ActionResult> GetAll()
        {
            try
            {

                var stock = await _stockManagment.GetAllProductsAsync();
                return Ok(stock);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);  
            }

        }

    }
}
