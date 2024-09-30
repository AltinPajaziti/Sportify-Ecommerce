using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produktet = sportify.core.cs.Products;

namespace sportify.Datalayer.Repository
{
    public class BasketRepo : IBasket
    {

        private readonly SportifyContext _context;
        private readonly IToken _token;


        public BasketRepo(  SportifyContext context , IToken token)
        {
            _context = context;
            _token = token;
            
        }


        public Task<IEnumerable<Produktet>> AddToBasket(ProductDto product)
        {

            var product = _context.products.
          

            
        }
    }
}
