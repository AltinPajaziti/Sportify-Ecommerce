using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.DTOs
{
    public class ProductDto
    {
        public int id { get; set; }
        public Guid GId { get; set; }
        public int? Productid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; } = 0;
        public string Photo { get; set; }

        public long Categoryid { get; set; }
    }
}
