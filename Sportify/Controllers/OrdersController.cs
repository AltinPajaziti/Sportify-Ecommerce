using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using sportify.Datalayer.Repository;
namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrders _rdersRepo;


        public OrdersController(IOrders rdersRepo)
        {
            _rdersRepo = rdersRepo;
        }




        [HttpGet("Get-All-Orders")]

        public async Task<ActionResult<List<OdersDto>>> GetProducts()
        {
            try
            {
                var Orders = await _rdersRepo.GetAllORders();

                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
