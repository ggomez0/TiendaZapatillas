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
       

    }
}