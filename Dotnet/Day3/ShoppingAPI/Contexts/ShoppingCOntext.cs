using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;

namespace ShoppingAPI.Contexts
{
    public class ShoppingCOntext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShoppingCOntext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(cart =>
            {
                cart.HasOne<Customer>().WithOne(c => c.Cart).HasForeignKey<Cart>(c => c.CustId).OnDelete(DeleteBehavior.NoAction);
            });
        }

    }
}
