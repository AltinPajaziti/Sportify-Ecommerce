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


        public Products(SportifyContext context , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
        }


        public async Task<List<ProductDto>> GetProducts()
        {
            var productEntities = await _context.products.ToListAsync();

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

        public async Task AddToFav(int productid)
        {
            var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var user = await _context.users.Include(u => u.FavoriteProducts).FirstOrDefaultAsync(u => u.id == userid);


            if (user == null)
            {
                throw new Exception("user is null");
            }

            var Favoriteprod = user.FavoriteProducts.FirstOrDefault(p => p.id == productid);

            if(Favoriteprod != null)
            {
                throw new Exception("the fav prod exists");
            }
            else
            {
                var Favprod = new FavoriteProducts
                {
                    productid = productid,
                    Userid = userid,
                };
                user.FavoriteProducts.Add(Favprod);
                _context.SaveChangesAsync();
            }

       

  



        }

        public async Task<List<Produktet>> GetAllFavoriteProducts()
        {
            var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var products =  _context.products.Include(products => products.FavoriteProducts).Where(u => u.id == userid);

            return await products.ToListAsync();
        }



        public async Task UpdateFavoriteProduct(ProductDto product , int productid)
        {
            var userid = Int32.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var products = await _context.users.Include(f => f.FavoriteProducts).FirstOrDefaultAsync(u => u.id == userid);


            if(products == null)
            {
                throw new Exception("The ser is null");
            }

            var actualproduct = products.FavoriteProducts.Where(p => p.productid == productid);
            if(actualproduct != null)
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



        public async  Task<Produktet> CreateProduct(ProductDto product)
        {
            if(product != null)
            {
                var Produkti = new Produktet
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Photo = product.Photo

                };

                await _context.products.AddAsync(Produkti);
                await _context.SaveChangesAsync(); 

                return  Produkti;
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

  



        public async Task<List<Produktet>> GetPriceFiltered(PriceProductFilter productPrice)
        {
            var filteredProducts = await _context.products
                .Where(p => p.Price > productPrice.price || p.Price < productPrice.price || p.Price == productPrice.price)
                .ToListAsync();

            return filteredProducts;
        }

        public Task<List<Produktet>> FilterProducts(FilterProductsDto products)
        {
            var query = _context.products.AsQueryable();
            if (!string.IsNullOrEmpty(products.Input))
            {
                query = query.Where(p => p.Name.Contains(products.Input) || p.Description.Contains(products.Input));
            }

            //if (!string.IsNullOrEmpty(location))
            //{
            //    query = query.Where(p => p.Location == location);
            //}

            if (products.PriceFrom.HasValue)
            {
                query = query.Where(p => p.Price >= products.PriceFrom.Value);
            }

            if (products.PriceTo.HasValue)
            {
                query = query.Where(p => p.Price <= products.PriceTo.Value);
            }

            return query.ToListAsync();
        }
    }
}
