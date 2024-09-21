
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






        }

    }




}
