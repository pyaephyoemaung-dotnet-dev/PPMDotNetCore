using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.RestApi.Db;
using PPMDotNetCore.Shared;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7134",
                                              "http://localhost:5018")
                          .WithMethods("GET","POST","PATCH","PUT","DELETE")
                          .AllowAnyHeader();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
//builder.Services.AddScoped<AdoDotNetService>(n => new AdoDotNetService("connectionString"));
//builder.Services.AddScoped<DapperService>(n => new DapperService("connectionString"));

builder.Services.AddDbContext<AddDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
builder.Services.AddScoped(n => new AdoDotNetService("connectionString"));
builder.Services.AddScoped(n => new DapperService("connectionString"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
