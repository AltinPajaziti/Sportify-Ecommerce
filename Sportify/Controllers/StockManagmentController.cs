using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.DTOs;
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


        [HttpPost("Add-stock")]
        public async Task<IActionResult> AddStock(AddStockDto stock)
        {
            if (stock == null || stock.Productid <= 0 || stock.Stock <= 0)
            {
                return BadRequest("Invalid input data. Please provide valid product ID and stock quantity.");
            }

            try
            {
                Console.WriteLine($"AddStock called with ProductId: {stock.Productid}, Stock: {stock.Stock}");
                await _stockManagment.AddStock(stock.Productid, stock.Stock);
                return Ok(new { message = "Product stock added successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in controller: {ex.Message}\n{ex.StackTrace}");
                return StatusCode(500, "An error occurred while adding stock.");
            }
        }


    }
}
