using APIController.Business.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace APIController.Data.DataContext
{
    public class APIControllerDataContext : DbContext
    {
        public APIControllerDataContext()
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var user = "sa1";
            var password = "sa123456";
            var dataSource = "DESKTOP-I32JP22";

            var connectionString = $"Initial Catalog=APIControllerDb;Persist Security Info=True;User ID={user};Password={password};Data Source={dataSource}";
            optionsBuilder.UseSqlServer(connectionString, e => e.MigrationsAssembly("APIController.Data")); //em qual projeto as migrations serão salvas
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
