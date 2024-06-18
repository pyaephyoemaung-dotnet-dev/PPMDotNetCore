using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.RestApi;
using PPMDotNetCore.RestApi.Models;

namespace PPMDotNetCore.RestApi.Db
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        //}
        public DbSet<BlogsModel> Blogs { get; set; }
    }
}
