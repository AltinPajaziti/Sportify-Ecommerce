using Microsoft.AspNetCore.Mvc;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface IStockManagment
    {
        Task<List<StockProductDto>> GetAllProductsAsync();
        Task AddStock(int productid , int stock);
    }
}
