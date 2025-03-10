using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class BasketProduct 
    {
        [Key]
        public int BasketProductID { get; set; }

        public int BasketId { get; set; }
        public Basket basket { get; set; }

        public int Productid { get; set; }
        public Products products { get; set; }

        public bool? IsPurchased { get; set; }
        public int Qty { get; set; }

    }
}
