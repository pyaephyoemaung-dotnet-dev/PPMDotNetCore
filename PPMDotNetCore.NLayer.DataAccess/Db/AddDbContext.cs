
using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.NLayer.DataAccess.Models;

namespace PPMDotNetCore.NLayer.DataAccess.Db
{
    public class AddDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogsModel> Blogs { get; set; }
    }
}
