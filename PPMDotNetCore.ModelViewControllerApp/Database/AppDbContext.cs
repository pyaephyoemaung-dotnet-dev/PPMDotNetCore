using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.ModelViewControllerApp.Models;

namespace PPMDotNetCore.ModelViewControllerApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
