using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Repository
{
    public class OrdersRepo : IOrders
    {
        private readonly SportifyContext _context;

        public OrdersRepo(SportifyContext context)
        {
            _context = context;
        }
        public async Task<List<OdersDto>> GetAllORders()
        {
            var purched = await  _context.basket.Include(u => u.users).Include(b => b.BasketProducts).ThenInclude(b=>b.products).ToListAsync();


            

           
            var listafinale = new List<OdersDto>(); 

    
            foreach (var od in purched)
            {
                var value = od.BasketProducts.Where(bp => bp.IsPurchased == true);
                foreach (var item in value)
                {
                    if(item.IsPurchased == true)
                    {
                        if (item.products != null && item.basket != null && item.basket.users != null)
                        {


                            var Qty = item.basket.BasketProducts.Where(bp => bp.BasketProductID == item.BasketProductID).Select(it => it.Qty).First();
                            var productprice = _context.products.Where(p => p.id == item.Productid).Select(p => p.Price).First();

                            var finalprice = Qty * productprice;


                            listafinale.Add(new OdersDto
                            {
                                ProductName = item.products.Name,
                                ClientName = item.basket.users.Name,
                                Quantity = Qty,
                                Price = finalprice,



                            });
                        }

                    }
                    
                }



            }

            return listafinale;

        }
    }
}
