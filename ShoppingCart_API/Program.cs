using Microsoft.EntityFrameworkCore;
using ShoppingCart_API;
using ShoppingCart_Model;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext configuration
builder.Services.AddDbContext<SecurityData_Context>(
    options => options.UseInMemoryDatabase("SecurityDb"));

builder.Services.AddDbContext<Data_Context>(
    options => options.UseInMemoryDatabase("DataContext"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
