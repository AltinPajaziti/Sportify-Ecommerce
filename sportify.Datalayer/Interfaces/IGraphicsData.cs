using sportify.Datalayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface IGraphicsData
    {
        Task<MonthlyChartDto> GetMonthlySales();

        Task<YearChartDto> GetYearlySales(); 


    }
}
