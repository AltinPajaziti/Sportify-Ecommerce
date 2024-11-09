using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.core.cs;
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


        [HttpPost("AddToFavorites/{productid}")]
        [Authorize]
        public async Task<IActionResult> AddToFavorites(int productid)
        {
            try
            {
                
                var result = await _products.AddToFav(productid);

                if (result != null)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Product added to favorites successfully",
                        ProductId = productid
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Failed to add product to favorites"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }


        [HttpGet("Get-All-Favorite-Products") , Authorize]

        public async Task<ActionResult<List<Produktet>>> GetAllFavoriteProducts()
        {
            try
            {
                var produktet = await _products.GetAllFavoriteProducts();

                return Ok(produktet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("Get-All-PurchasedProducts"), Authorize]

        public async Task<ActionResult<List<Produktet>>> PurchasedProducts()
        {
            try
            {
                var produktet = await _products.PurchasedProducts();

                return Ok(produktet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Getpurchedcount") , Authorize]

        public async Task<IActionResult> Getpurchedcount()
        {
            try
            {
                var favoritecount = await _products.Getpurchedcount();

                return Ok(favoritecount);
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

        [HttpGet("Get-favorite-count")]

        public async Task<IActionResult> GetFAvoritecount()
        {
            try
            {
                var favoritecount = await _products.GetFavoriteCountAsync();

                return Ok(favoritecount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpDelete("Remove-fav-product/{productid}")]
        public async Task<ActionResult<bool>> RemoveFavoriteProduct(int productid)
        {
            try
            {
                var favDeleted = await _products.DeleteFavProduct(productid);

                if (!favDeleted)
                {
                    return NotFound("Product not found in favorites."); // Return 404 if the product wasn't found
                }

                return Ok(favDeleted); // Return 200 OK with the result
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return BadRequest($"An error occurred: {ex.Message}"); // Return 400 Bad Request on error
            }
        }



    }
}
