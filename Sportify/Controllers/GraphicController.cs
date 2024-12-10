using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphicController : ControllerBase
    {
        private readonly IGraphicsData _graphics;

        public GraphicController( IGraphicsData graphics)
        {
            _graphics = graphics;
        }


        [HttpGet("Get-Monthly")]
        public async Task<ActionResult<MonthlyChartDto>> GetMonthly()
        {
            try
            {
                var monthly = await _graphics.GetMonthlySales();

                return Ok(monthly); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }


        [HttpGet("Get-Year-data")]
        public async Task<ActionResult<YearChartDto>> GetDAta()
        {
            try
            {
                var monthly = await _graphics.GetYearlySales();

                return Ok(monthly);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
