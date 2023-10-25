using System.Collections.Generic;
using System.Data.Entity;
namespace TiendaZapatillas.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("TiendaZapatillas")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeCategory> TypeCategories { get; set; }
        public DbSet<GeneroCategory> GeneroCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Sprint 2

        public DbSet<comprobantes> comprobantes { get; set; }
        public DbSet<depositos> depositos { get; set; }
        public DbSet<Cards> Card { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<historial> historials { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<prodendep> prodendeps { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
    }
}