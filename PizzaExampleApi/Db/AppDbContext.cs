using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace PizzaExampleApi.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<PizzaModel> Pizza { get; set; }
    }
    [Table("tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        public int PizzaId { get; set; }
        public string? PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
    }
}
