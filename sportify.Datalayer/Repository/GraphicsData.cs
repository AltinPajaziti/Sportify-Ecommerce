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

            var thisYearMonthlySales = new List<dynamic>();
            for (int month = 1; month <= 12; month++)
            {
                thisYearMonthlySales.Add(new { Month = month, TotalSales = 0 });
            }

            var thisYearSales = await _context.basket
                .Include(b => b.BasketProducts)
                .Where(b => b.LastModified.HasValue && b.LastModified.Value.Year == currentYear)
                .SelectMany(b => b.BasketProducts)
                .Where(bp => bp.IsPurchased == true)
                .GroupBy(bp => bp.basket.LastModified.Value.Month) // Group by month
                .Select(g => new
                {
                    Month = g.Key, // The month number (1 = January, 2 = February, ...)
                    TotalSales = g.Sum(bp => bp.Qty) // Sum of quantities for this month
                })
                .OrderBy(g => g.Month) // Order by month
                .ToListAsync();

            // Populate the sales data into the thisYearMonthlySales list
            foreach (var sales in thisYearSales)
            {
                var monthIndex = sales.Month - 1; // Adjust for zero-based index (0 = January, 11 = December)
                thisYearMonthlySales[monthIndex] = new { Month = sales.Month, TotalSales = sales.TotalSales };
            }

            // Now for last year, initialize the list for all 12 months with zero sales
            var lastYearMonthlySales = new List<dynamic>();
            for (int month = 1; month <= 12; month++)
            {
                lastYearMonthlySales.Add(new { Month = month, TotalSales = 0 });
            }

            var lastYear = currentYear - 1;

            // Get the sales data for last year
            var lastYearSales = await _context.basket
                .Include(b => b.BasketProducts)
                .Where(b => b.LastModified.HasValue && b.LastModified.Value.Year == lastYear)
                .SelectMany(b => b.BasketProducts)
                .Where(bp => bp.IsPurchased == true)
                .GroupBy(bp => bp.basket.LastModified.Value.Month) // Group by month
                .Select(g => new
                {
                    Month = g.Key, // The month number (1 = January, 2 = February, ...)
                    TotalSales = g.Sum(bp => bp.Qty) // Sum of quantities for this month
                })
                .OrderBy(g => g.Month) // Order by month
                .ToListAsync();

            // Populate the sales data into the lastYearMonthlySales list
            foreach (var sales in lastYearSales)
            {
                var monthIndex = sales.Month - 1; // Adjust for zero-based index (0 = January, 11 = December)
                lastYearMonthlySales[monthIndex] = new { Month = sales.Month, TotalSales = sales.TotalSales };
            }

            // Create the final result to return
            var finalResult = new YearChartDto
            {
                ThisYear = thisYearMonthlySales, // The complete list of monthly sales for this year
                LastYear = lastYearMonthlySales, // The complete list of monthly sales for last year
            };

            return finalResult;
        }

    }
}
