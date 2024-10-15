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
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Token { get; set; }
        public int StockQuantity { get; set; } = 0;
        public string Photo { get; set; }

    }
}
