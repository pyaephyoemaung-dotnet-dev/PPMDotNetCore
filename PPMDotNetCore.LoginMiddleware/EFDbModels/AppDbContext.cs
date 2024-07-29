using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPMDotNetCore.LoginMiddleware.EFDbModels;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<LoginModel> Login { get; set; }
}
[Table("Table_Login")]
public class LoginModel
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public string SessionId { get; set; }
    public DateTime SessionExp { get; set; }
}
[Table("Table_Client")]
public class UserModel
{
    [Key]
    public string UserId { get; set; }
    public string UserName { get; set; }
    public int Password { get; set; }
}    
