using Microsoft.EntityFrameworkCore;
using NLayerTesting;
using NLayerTesting.Model;

namespace NLayerTesting.DataBase
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectingString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModels> Blogs { get; set; }
    }
}
