using Microsoft.Extensions.Configuration;
using OnlineSales.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSales.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Configuration;
;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<SalesDbContext>(options =>
    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
    //options.UseSqlite("Data Source=online_sales.db"));

    services.AddScoped<Product>();
    services.AddControllers();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
