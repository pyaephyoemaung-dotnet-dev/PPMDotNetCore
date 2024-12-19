using Microsoft.EntityFrameworkCore;
using WebApplication.N_Layer.Model;

namespace WebApplication.N_Layer.DataBase
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
