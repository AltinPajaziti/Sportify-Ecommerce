using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.core.cs
{
    public class FavoriteProducts : BaseEntity
    {
        public Products Produktet { get; set; }
        public int productid { get; set; }


        public Users Userat { get; set; }
        public int Userid { get; set; }

        public int Quantity { get; set; }
    }
}
