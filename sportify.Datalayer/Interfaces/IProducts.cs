using sportify.core.cs;
using sportify.Datalayer.Repository;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using Products = sportify.core.cs.Products;

namespace sportify.Datalayer.Interfaces
{
    public interface IProducts
    {
        Task<List<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(Guid id);

        Task<Products> CreateProduct(ProductDto product);

        Task<List<Products>> GetFilterProducts(ProductNameFilter productName);

        Task<List<Products>> GetPriceFiltered(PriceProductFilter productPrice);

        Task<bool> AddToFav(int productid);
        Task<List<ProductDto>> GetAllFavoriteProducts();

        Task<int> GetFavoriteCountAsync();


        Task<List<Products>> FilterProducts(FilterProductsDto products);

        Task<List<Products>> PurchasedProducts();

        Task<bool> DeleteFavProduct(int productid);



    }
}
