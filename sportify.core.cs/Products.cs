

namespace sportify.core.cs
{
    public class Products : BaseEntity
    {
        public Products()
        {
            GId = Guid.NewGuid(); 
        }
        public Guid GId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Photo { get; set; }

        public int Stockid { get; set; }
        public Stock stock { get; set; }

        public ICollection<FavoriteProducts> FavoriteProducts { get; set; }

        public Category Category { get; set; }


        public ICollection<BasketProduct> BasketProducts { get; set; }




    }
}
