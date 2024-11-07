using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Produktet = sportify.core.cs.Products;


namespace sportify.Datalayer.Repository
{
    public class Products : IProducts
    {
        public readonly SportifyContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public Products(SportifyContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
        }


        public async Task<List<ProductDto>> GetProducts()
        {
            var productEntities = await _context.products.Include(p=> p.Category).ToListAsync();

            List<ProductDto> Products = new List<ProductDto>();

            foreach (var product in productEntities)
            {
                Products.Add(new ProductDto
                {
                    id = product.id,
                    Name = product.Name,
                    Description = product.Description,
                    Photo = product.Photo,
                    Price = product.Price,
                    Categoryid = product.Category.id
                }
                );
            }

            return Products;


        }
        public async Task<List<Produktet>> FilterByPrice(int FromPrice, int ToPrice)
        {
            var produktet = await _context.products
                .Where(p => p.Price >= FromPrice && p.Price <= ToPrice)
                .ToListAsync();

            return produktet;
        }






        public async Task<ProductDto> GetProductById(Guid id)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.GId == id);

            if (product != null)
            {
                return new ProductDto
                {
                    Name = product.Name,
                    Description = product.Description,
                    Photo = product.Photo,
                    Price = product.Price,
                };


            }

            return null;
        }

        public async Task<bool> AddToFav(int productid)
        {
            var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var user = await _context.users.Include(u => u.FavoriteProducts).FirstOrDefaultAsync(u => u.id == userid);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var favoriteProd = user.FavoriteProducts.FirstOrDefault(p => p.productid == productid);

            if (favoriteProd != null)
            {
                favoriteProd.Quantity++;
                await _context.SaveChangesAsync();

                return true;
            }

            var newFavProd = new FavoriteProducts
            {
                productid = productid,
                Userid = userid,
                Quantity = 1
            };
            user.FavoriteProducts.Add(newFavProd);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<ProductDto>> GetAllFavoriteProducts()
        {
            var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (userid == null)
            {
                throw new Exception("The userid is null");
            }
            var products = await _context.products.Include(products => products.FavoriteProducts)
                .Where(products => products.FavoriteProducts
                .Any(fp => fp.Userid == userid)).ToListAsync();

            var FinalProducts = products.Select(p => new ProductDto
            {
                Productid = p.id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Photo = p.Photo,


            }).ToList();





            return FinalProducts.Count > 0 ? FinalProducts : new List<ProductDto>();

        }



        public async Task UpdateFavoriteProduct(ProductDto product, int productid)
        {
            var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var products = await _context.users.Include(f => f.FavoriteProducts).FirstOrDefaultAsync(u => u.id == userid);


            if (products == null)
            {
                throw new Exception("The ser is null");
            }

            var actualproduct = products.FavoriteProducts.Where(p => p.productid == productid);
            if (actualproduct != null)
            {
                _context.Remove(actualproduct);
            }

            var newFavoriteProduct = new FavoriteProducts
            {
                productid = productid,
                Userid = userid
            };

            products.FavoriteProducts.Add(newFavoriteProduct);

            await _context.SaveChangesAsync();





        }



        public async Task<Produktet> CreateProduct(ProductDto productDto)
        {
            if (productDto != null)
            {
                var existingProduct = await _context.products
                    .Include(p => p.stock)
                    .FirstOrDefaultAsync(p => p.id == productDto.id);

                if (existingProduct != null)
                {
                    if (existingProduct.stock != null)
                    {
                        existingProduct.stock.Quantity = productDto.StockQuantity;
                    }
                }
                else
                {
                    var newStock = new Stock
                    {
                        Quantity = productDto.StockQuantity
                    };

                    var newProduct = new Produktet
                    {
                        Name = productDto.Name,
                        Description = productDto.Description,
                        Price = productDto.Price,
                        Photo = productDto.Photo,
                        stock = newStock
                    };

                    await _context.products.AddAsync(newProduct);

                    await _context.SaveChangesAsync();

                    newProduct.Stockid = newStock.Stockid;
                }

                await _context.SaveChangesAsync();

                return existingProduct;
            }

            return null;
        }



        public async Task<List<Produktet>> GetFilterProducts(ProductNameFilter productName)
        {
            var filteredProducts = await _context.products
                .Where(p => p.Name.Contains(productName.Name))
                .ToListAsync();

            return filteredProducts;
        }




        public async Task<int> GetFavoriteCountAsync()
        {
            // Test with a hardcoded user ID (e.g., 2)
            int testUserId = 2;

            //var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


            // Get the count of favorite products for the hardcoded user ID
            var favoriteCount = await _context.favoriteProducts.CountAsync(fp => fp.Userid == testUserId);
            return favoriteCount;
        }





        public async Task<List<Produktet>> GetPriceFiltered(PriceProductFilter productPrice)
        {
            var filteredProducts = await _context.products
                .Where(p => p.Price > productPrice.price || p.Price < productPrice.price || p.Price == productPrice.price)
                .ToListAsync();

            return filteredProducts;
        }

        public Task<List<Produktet>> FilterProducts(FilterProductsDto products)
        {
            var query = _context.products.Include(p=>p.Category).AsQueryable();
            if (!string.IsNullOrEmpty(products.Input))
            {
                query = query.Where(p => p.Name.Contains(products.Input));
            }

            if (products.sortby != null)
            {
                if (products.sortby.ToLower() == "asc")
                {
                    query = query.OrderBy(p => p.Name);

                }

                if (products.sortby.ToLower() == "desc")
                {
                    query = query.OrderByDescending(p => p.Name);
                }
            }

            if(products.Categoryid != null)
            {
                query = query.Where(p => p.Category.id == products.Categoryid);
            }




            if (products.PriceFrom != 0)
            {
                query = query.Where(p => p.Price >= products.PriceFrom.Value);
            }

            if (products.PriceTo != 0)
            {
                query = query.Where(p => p.Price <= products.PriceTo.Value);
            }

            return query.ToListAsync();
        }

        public async Task<List<Produktet>> PurchasedProducts()
        {
            var userIdClaim = _contextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                throw new Exception("User ID not found in claims.");
            }

            var purchasedProducts = await _context.users
                .Where(u => u.id == userId)
                .Include(u => u.Basket)
                    .ThenInclude(b => b.BasketProducts)
                        .ThenInclude(bp => bp.products)
                .SelectMany(u => u.Basket.BasketProducts
                    .Where(bp => bp.IsPurchased == true && bp.basket.userid == userId)
                    .Select(bp => bp.products))
                .ToListAsync();

            return purchasedProducts;
        }


        public async Task<bool> DeleteFavProduct(int productId)
        {
            var product = await _context.favoriteProducts.FirstOrDefaultAsync(p => p.productid == productId);

            if (product == null)
            {
                return false;
            }

            _context.favoriteProducts.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

    }
}