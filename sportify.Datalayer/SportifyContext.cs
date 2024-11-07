
using Microsoft.EntityFrameworkCore;
using sportify.core.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace sportify.Datalayer
{
    public class SportifyContext : DbContext
    {
        public DbSet<Products>products { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Basket> basket { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Stock> stock { get; set; }

        public DbSet<FavoriteProducts> favoriteProducts { get; set; }


        public SportifyContext( DbContextOptions<SportifyContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
            .HasOne(r => r.Roli)
            .WithMany(u => u.User)
            .HasForeignKey(f => f.Roleid)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<BasketProduct>()
            .HasKey(bp => new { bp.BasketId, bp.Productid });



            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.basket)
                .WithMany(b => b.BasketProducts)
                .HasForeignKey(bp => bp.BasketId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.products)
                .WithMany(p => p.BasketProducts)
                .HasForeignKey(bp => bp.Productid);


            //
            modelBuilder.Entity<FavoriteProducts>()
           .HasKey(bp => new { bp.Userid, bp.productid });

            modelBuilder.Entity<Products>()
                  .HasOne(p => p.stock)  
                  .WithOne(s => s.Product)  
                  .HasForeignKey<Stock>(s => s.ProductId)  
                  .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<FavoriteProducts>()
                .HasOne(bp => bp.Userat)
                .WithMany(b => b.FavoriteProducts)
                .HasForeignKey(bp => bp.Userid);

            modelBuilder.Entity<FavoriteProducts>()
                .HasOne(bp => bp.Produktet)
                .WithMany(p => p.FavoriteProducts)
                .HasForeignKey(bp => bp.productid);

            modelBuilder.Entity<Users>()
           .HasOne(u => u.Basket)
           .WithOne(c => c.users)
           .HasForeignKey<Basket>(c => c.userid)
           .OnDelete(DeleteBehavior.Cascade);

        }

    }




}
