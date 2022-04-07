using Microsoft.EntityFrameworkCore;


namespace PostegreSQLConnectTest
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
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
                    "Database = userdb;" + //take u DB
                    "User ID = postgres;" +
                    "Password = 123123123"// change pass on u settings
                );
        }
    }
}
