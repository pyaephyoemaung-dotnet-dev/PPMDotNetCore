using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.BlazorCRUDApp.Model;

namespace PPMDotNetCore.BlazorCRUDApp
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
