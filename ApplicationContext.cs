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
                    "Database = userdb;" +
                    "User ID = postgres;" +
                    "Password = 159357yarik101"
                );
        }
    }
}
