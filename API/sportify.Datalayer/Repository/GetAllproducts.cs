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

        public async Task AddStock(int productid, int stock)
        {
            try
            {
                // Find the product
                var product = await _context.products.FirstOrDefaultAsync(p => p.id == productid);
                if (product == null)
                {
                    throw new ArgumentException($"Product with ID {productid} does not exist.");
                }

                // Find the stock entry
                var productStock = await _context.stock.FirstOrDefaultAsync(s => s.ProductId == productid);
                if (productStock != null)
                {
                    productStock.Quantity += stock;
                }
                else
                {
                    // Create a new stock entry
                    var newStock = new Stock
                    {
                        ProductId = productid,
                        Quantity = stock,
                        Product = product
                    };

                    await _context.stock.AddAsync(newStock);
                }

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error in AddStock: {ex.Message}\n{ex.StackTrace}");
                throw; // Re-throw the exception to propagate it
            }
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
