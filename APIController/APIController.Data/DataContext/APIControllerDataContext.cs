using APIController.Business.Entity.Logs;
using APIController.Business.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;

namespace APIController.Data.DataContext
{
    public class APIControllerDataContext : DbContext
    {
        protected IConfiguration _config;
        public APIControllerDataContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ApiTokenLog> ApiTokenLogs { get; set; }
        public DbSet<ApiAccessLog> ApiAccessLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("DatabaseConnection");

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer(connectionString, e => e.MigrationsAssembly("APIController.Data")); //em qual projeto as migrations serão salvas
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
