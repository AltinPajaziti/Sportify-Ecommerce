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
    public class GraphicsData : IGraphicsData
    {
        private readonly SportifyContext _context;

        public GraphicsData(SportifyContext context)
        {
            _context = context;

        }
        public async Task<MonthlyChartDto> GetMonthlySales()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var purchasedQtySum = await _context.basket
                .Include(b => b.BasketProducts)
                .Where(b => b.LastModified.HasValue &&
                            b.LastModified.Value.Month == currentMonth &&
                            b.LastModified.Value.Year == currentYear)
                .Where(b => b.BasketProducts.Any(bp => bp.IsPurchased == true))
                .SelectMany(b => b.BasketProducts)
                .Where(bp => bp.IsPurchased == true)
                .SumAsync(bp => bp.Qty);


            var productsinstock = await _context.stock.SumAsync(bp => bp.Quantity);


            var categoryCount = _context.category.Count();

            var Total = new MonthlyChartDto
            {
                Stock = productsinstock,
                Category = categoryCount,
                Purchedproducts = purchasedQtySum,
            };


            return Total;
        }

        public async Task<YearChartDto> GetYearlySales()
        {

            var currentYear = DateTime.Now.Year;

            var thisyear = await  _context.basket
                .Include(b => b.BasketProducts)
                .Where(b => b.LastModified.HasValue &&
                           
                            b.LastModified.Value.Year == currentYear)
                .Where(b => b.BasketProducts.Any(bp => bp.IsPurchased == true))
                .SelectMany(b => b.BasketProducts)
                .Where(bp => bp.IsPurchased == true)
                .SumAsync(bp => bp.Qty);



            var lastYear = DateTime.Now.Year - 1;


            var aboutLastYear = await _context.basket
                .Include(b => b.BasketProducts)
                .Where(b => b.LastModified.HasValue &&

                            b.LastModified.Value.Year == lastYear)
                .Where(b => b.BasketProducts.Any(bp => bp.IsPurchased == true))
                .SelectMany(b => b.BasketProducts)
                .Where(bp => bp.IsPurchased == true)
                .SumAsync(bp => bp.Qty);


            var finalresult = new YearChartDto
            {
                ThisYear = thisyear,
                LastYear = aboutLastYear,
            };
            return finalresult; 

        }

    }
}
