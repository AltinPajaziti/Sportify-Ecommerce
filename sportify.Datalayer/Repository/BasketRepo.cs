using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produktet = sportify.core.cs.Products;

namespace sportify.Datalayer.Repository
{
    public class BasketRepo : IBasket
    {

        private readonly SportifyContext _context;
        private readonly IToken _token;


        public BasketRepo(  SportifyContext context , IToken token)
        {
            _context = context;
            _token = token;
            
        }


        public Task<IEnumerable<Produktet>> AddToBasket(ProductDto product)
        {

            var userid = _token.GetUserIdFromToken(product.Token);

            if(userid == null)
            {
                throw new Exception("you should be logged in");
            }

            var basket = _context.basket.Include(b => b.BasketProducts).FirstOrDefault(u=>u.userid == Int32.Parse(userid)) ?? new Basket
            {
                userid = Int32.Parse(userid),
                BasketProducts = new List<BasketProduct>()
            };


            if (!basket.BasketProducts.Any(bp => bp.Productid == product.id))
            {
                // Add the product to the basket
                basket.BasketProducts.Add(new BasketProduct
                {
                    BasketId = basket.userid,
                   // ProductId = product.ProductId
                });
            }

            //if (basket.BasketId == 0)
            //{
            //    _context.Baskets.Add(basket);
            //}

            // Save changes to the database
            //await _context.SaveChangesAsync();

            // Return the updated products in the basket
            //return basket.BasketProducts.Select(bp => bp.Product);









        }
    }
}
