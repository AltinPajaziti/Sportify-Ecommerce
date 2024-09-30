using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class BasketProduct : BaseEntity
    {
        public int BasketId { get; set; }
        public Basket basket { get; set; }


        public int Productid { get; set; }
        public Products products { get; set; }

    }
}
