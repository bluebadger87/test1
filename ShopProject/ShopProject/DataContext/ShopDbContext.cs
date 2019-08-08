using Microsoft.EntityFrameworkCore;
using ShopProject.Models;

namespace ShopProject.DataContext
{
   public class ShopDbContext : DbContext
   {
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(@"User ID=bluebadger;Password=wjswk87!@!@;Initial Catalog=ShopDB;Data Source=bluebadger.iptime.org");
      }
      public DbSet<ProductCategoryList> ProductCategoryList { get; set; }
      public DbSet<Product> Product { get; set; }
      public DbSet<ProductImages> ProductImages { get; set; }
      public DbSet<User> User { get; set; }
      public DbSet<Order> Order { get; set; }
      public DbSet<OrderDetail> OrderDetail { get; set; }
      public DbSet<ProductComment> ProductComment { get; set; }
      public DbSet<Country> Country { get; set; }
      public DbSet<State> State { get; set; }
      public DbSet<City> City { get; set; }
   }
}
