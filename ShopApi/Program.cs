using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopApi.Data;
using ShopApi.Services.CustomerServices;
using ShopApi.Services.OderServices;
using ShopApi.Services.ProductServices;
using ShopApi.Services.SupplierServices;
using System.Security.AccessControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddScoped<ICustomerServices, CustomerServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();    
builder.Services.AddScoped<ISupplierServices, SupplierServices>();
builder.Services.AddScoped<IOrderServices, OrderSevices>();
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
