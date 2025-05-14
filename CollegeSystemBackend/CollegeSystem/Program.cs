using Microsoft.EntityFrameworkCore;
using CollegeSystem.DBConnect;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))));

//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseAuthorization();

app.MapControllers();

app.Run();
