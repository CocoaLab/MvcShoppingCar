using System.Data.Entity;

namespace MvcShoppingCar.Models
{
    public class MVCShoppingContext:DbContext
    {
        public MVCShoppingContext()
            : base("name = DefaultConnection")
        { 
        
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Member> MemberS { get; set; }
        public DbSet<OrderHead> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetailitems { get; set; }


    }
}