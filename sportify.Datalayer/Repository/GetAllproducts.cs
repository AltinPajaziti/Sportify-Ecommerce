using Microsoft.AspNetCore.Mvc;
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
    public class GetAllproducts : IStockManagment
    {
        private readonly SportifyContext _context;



        public GetAllproducts(SportifyContext context)
        {
            _context = context; 
        }

        public async Task  AddStock(int productid, int stock)
        {

            var product = await _context.products.Where(p => p.id == productid).FirstOrDefaultAsync();


            if (product != null)
            {
               var productstock =  await _context.products.Include(p => p.stock).Where(p => p.stock.ProductId == productid).FirstOrDefaultAsync();

                if(productstock != null)
                {
                    productstock.stock.Quantity = stock;
                }
                else
                {
                    var newstock = new Stock
                    {
                        Product = product,
                        ProductId = productid,
                        Quantity = stock
                    };

                     _context.stock.Add(newstock);
                }

               
            }
            await _context.SaveChangesAsync();


        }

        public async Task<List<StockProductDto>> GetAllProductsAsync()
        {
            
            return await _context.products
                                 .Include(p => p.stock) 
                                 .Where(p => p.stock.ProductId == p.id).Select( p => new StockProductDto
                                 {
                                     id  = p.id,    
                                     Name = p.Name,
                                     Description = p.Description,
                                     Price = p.Price,
                                     Quantity = p.stock.Quantity,
                                 })
                                 .ToListAsync();


        }
    }
}
