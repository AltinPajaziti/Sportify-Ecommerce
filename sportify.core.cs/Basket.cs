using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class Basket : BaseEntity
    {
       

        public ICollection<BasketProduct> BasketProducts { get; set; }


        public int userid { get; set; }
        public Users users { get; set; }
    }
}
