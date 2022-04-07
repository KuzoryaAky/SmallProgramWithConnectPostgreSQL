using Microsoft.EntityFrameworkCore;
using UI_test.Products;

namespace UI_test.DBConnect
{
    class ApplicationContext : DbContext
    {
        public DbSet<MProduct> products { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql
                (
                    "Host = localhost;" +
                    "Port = 5432;" +
                    "Database = productsdb;" +
                    "User ID = postgres;" +
                    "Password = 123123123"
                );
        }
    }
}
