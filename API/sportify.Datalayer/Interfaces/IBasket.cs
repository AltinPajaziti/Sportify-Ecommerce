

using sportify.core.cs;
using sportify.Datalayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface IBasket
    {
        Task<ProductDto> AddToBasket(ProductDto product);

        Task<bool> DeleteProduct(int pid);
        Task<ProductDto> BuyProduct(ProductDto product);

        Task<List<ProductDto>> GetAllPurchasedProductsAsync();

        Task<bool> DeleteBoughtProduct(int pid);


    }
}
