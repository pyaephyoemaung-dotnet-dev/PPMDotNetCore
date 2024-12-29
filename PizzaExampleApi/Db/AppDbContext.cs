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
        public DbSet<PizzaExtraModel> PizzaExtra { get; set; }
        public DbSet<PizzaOrderModel> PizzaOrder { get; set; }
        public DbSet<PizzaOrderDetailModel> PizzaDetail { get; set; }
    }
    [Table("tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        public int PizzaId { get; set; }
        public string? PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
    }
    [Table("tbl_PizzaExtra")]
    public class PizzaExtraModel
    {
        [Key]
        public int PizzaExtraId { get; set; }
        public string? PizzaExtraName { get; set; }
        public decimal PizzaPrice { get; set; }
    }
    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] Extra { get; set; }
    }
    [Table("tbl_PizzaOrder")]
    public class PizzaOrderModel
    {
        [Key]
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
    }
    [Table("tbl_PizzaDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
    }
    public class OrderMessage
    {
        public string message { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
