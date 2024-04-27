using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.RestApi;
using PPMDotNetCore.RestApi.Models;

namespace PPMDotNetCore.RestApi.Db
{
    internal class AddDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogsModel> Blogs { get; set; }
    }
}
