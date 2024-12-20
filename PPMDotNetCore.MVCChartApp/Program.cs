using Serilog;
using Serilog.Sinks.MSSqlServer;

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/PPMDotNetCore.ConsoleAppLogging.log");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(filePath, rollingInterval: RollingInterval.Hour)
    .WriteTo
    .MSSqlServer(
        connectionString: "Server=.;Database=PPMDotNetCore;User ID=sa;Password=sasa@123;TrustServerCertificate=True;",
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "Tbl_LogEvents",
            AutoCreateSqlTable = true
        })
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();

    
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

   
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
       
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}