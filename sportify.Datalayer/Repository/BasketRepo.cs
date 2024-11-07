using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Produktet = sportify.core.cs.Products;

namespace sportify.Datalayer.Repository
{
    public class BasketRepo : IBasket
    {

        private readonly SportifyContext _context;
        private readonly IToken _token;
        private readonly IHttpContextAccessor _contextAccessor;


        public BasketRepo(SportifyContext context, IToken token, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _token = token;
            _contextAccessor = httpContextAccessor;

        }
        //public async Task<ProductDto> AddToBasket(ProductDto product)
        //{
        //    var UseridClaim = _contextAccessor.HttpContext?.User.Claims
        //               .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        //    if (UseridClaim == null || !int.TryParse(UseridClaim, out int Userid))
        //    {
        //        throw new Exception("User ID not found in claims.");
        //    }
        //    var userExists = await _context.users.AnyAsync(u => u.id == Userid);
        //    if (!userExists)
        //    {
        //        throw new Exception("User does not exist");
        //    }

        //    var existingBasket = _context.basket.Include(b => b.BasketProducts).FirstOrDefault(b => b.userid == Userid);
        //    if (true)
        //    {
        //      var newbasket = new Basket
        //        {
                  
        //            userid = Userid,
        //            BasketProducts = new List<BasketProduct>()
        //        };
        //        _context.basket.Add(newbasket);


        //        var newBasketProduct = new BasketProduct
        //            {
        //                BasketId = newbasket.id,
        //                Productid = product.id,
        //                Qty = 1,
                        
                        
        //            };
        //        newbasket.BasketProducts.Add(newBasketProduct);          

        //    }
        //    else
        //    {
        //        var productExists = existingBasket.BasketProducts.FirstOrDefault(bp => bp.Productid == product.id);

        //        if (productExists == null)
        //        {
        //            var newBasketProduct = new BasketProduct
        //            {
        //                BasketId = existingBasket.id,
        //                Productid = product.id,
        //                Qty = 1
        //            };
        //            existingBasket.BasketProducts.Add(newBasketProduct);
        //        }
        //        else
        //        {
        //            productExists.Qty += 1;
        //        }

        //    }

           
            


        //    await _context.SaveChangesAsync();

        //    return product; 
        //}

        public async Task<bool>  DeleteProduct(int pid)
        {
            var UseridClaim = _contextAccessor.HttpContext?.User.Claims
                      .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (UseridClaim == null || !int.TryParse(UseridClaim, out int Userid))
            {
                throw new Exception("User ID not found in claims.");
            }

            var existingbucket = _context.basket.Include(b => b.BasketProducts).FirstOrDefault(b => b.userid == Userid);


            var product = existingbucket.BasketProducts.FirstOrDefault(p => p.Productid == pid);

          
                existingbucket.BasketProducts.Remove(product);
                if(existingbucket.BasketProducts.Count == 0)
                {
                    _context.basket.Remove(existingbucket);
                }

               
            

            await _context.SaveChangesAsync();
            return true;





        }


        public async Task<bool> AddToFav(int Productid)
        {
            var userid = 22;

            var user = await  _context.users.Include(fp => fp.FavoriteProducts).FirstOrDefaultAsync(fb => fb.id == userid);
            if (userid == null)
            {
                return false;
            }

            var FavoriteProduckt = user.FavoriteProducts.Any( p => p.productid == Productid );

            if(FavoriteProduckt != null)
            {
                return false;
            }

            var favprod = new FavoriteProducts
            {
                productid = Productid,
                Userid = userid
            };

            user.FavoriteProducts.Add(favprod);

            _context.SaveChangesAsync();

            return true;




        }

    

        public async Task<ProductDto> BuyProduct(ProductDto product)
        {

            this.AddToBasket(product);

            var UseridClaim = _contextAccessor.HttpContext?.User.Claims
                      .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (UseridClaim == null || !int.TryParse(UseridClaim, out int Userid))
            {
                throw new Exception("User ID not found in claims.");

            }

            var basket = await _context.basket
                .Include(b => b.BasketProducts)
                .FirstOrDefaultAsync(b => b.userid == Userid);

            if (basket == null)
            {
                throw new Exception("Basket not found for user.");
            }

            var test = basket.BasketProducts.FirstOrDefault(p => p.Productid == product.id);



            await _context.SaveChangesAsync();


            return product;




        }
        //{ }


        public async Task<ProductDto> AddToBasket(ProductDto product)
        {
            var UseridClaim = _contextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (UseridClaim == null || !int.TryParse(UseridClaim, out int Userid))
            {
                throw new Exception("User ID not found in claims.");
            }

            var existingProduct = await _context.products
                .Include(p => p.stock)
                .FirstOrDefaultAsync(p => p.id == product.id);

            if (existingProduct == null || existingProduct.stock == null || existingProduct.stock.Quantity < 1)
            {
                throw new Exception("The product is either out of stock or does not exist.");
            }

            var existingBasket = await _context.basket
                .Include(b => b.BasketProducts)
                .FirstOrDefaultAsync(b => b.userid == Userid);

            if (existingBasket != null)
            {
                var existingBasketProduct = existingBasket.BasketProducts
                    .FirstOrDefault(bp => bp.Productid == product.id);

                if (existingBasketProduct != null)
                {
                    existingBasketProduct.Qty += 1;
                    existingBasketProduct.IsPurchased = true;
                    
                    
                }
                else
                {
                    existingBasket.BasketProducts.Add(new BasketProduct
                    {
                        Productid = product.id,
                        Qty = 1,
                        IsPurchased = true,
                    });
                }
            }
            else
            {
                var newBasket = new Basket
                {
                    userid = Userid,
                    BasketProducts = new List<BasketProduct>
            {
                new BasketProduct
                {
                    Productid = product.id,
                    Qty = 1,
                    IsPurchased = true,
                }
            }
                };
                _context.basket.Add(newBasket);
            }

            existingProduct.stock.Quantity -= 1;
            _context.products.Update(existingProduct); 

            await _context.SaveChangesAsync();

            return product;
        }


        //  public async Task<Products> UpdateProduct(int id, ProductDto newproduct)
        //  {
        //      var UseridClaim = _contextAccessor.HttpContext?.User.Claims
        //                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        //      if (UseridClaim == null || !int.TryParse(UseridClaim, out int Userid))
        //      {
        //          throw new Exception("User ID not found in claims.");
        //      }

        //      var basket = await _context.basket
        //          .Include(b => b.BasketProducts)
        //          .FirstOrDefaultAsync(b => b.userid == Userid);

        //      if (basket == null)
        //      {
        //          throw new Exception("Basket not found for the user.");
        //      }

        //      var product = basket.BasketProducts.FirstOrDefault(p => p.Productid == id);
        //      if (product == null)
        //      {
        //          throw new Exception("Product not found in the basket.");
        //      }

        ////      product.Qty = newproduct.qty; 

        //      await _context.SaveChangesAsync();

        //  //    return product;
        //  }



    }
}


