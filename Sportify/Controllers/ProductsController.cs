using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.core.cs;
//[]
//{}
namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private static List<Products> _products = new List<Products>();


        [HttpPost , Authorize(Roles ="Admin")]
        public async Task<List<Products>> GetProducts(Products produkti)
        {

            _products.Add(produkti);    

            return _products;

            

        }



    }
}
