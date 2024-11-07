using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class Stock 
    {
        public int Stockid { get; set; }

        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int Quantity { get; set; }
    }
}
