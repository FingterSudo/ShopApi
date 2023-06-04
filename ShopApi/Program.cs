using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopApi.Data;
using ShopApi.DTO;
using ShopApi.Services.CustomerServices;
using ShopApi.Services.OderServices;
using ShopApi.Services.ProductServices;
using ShopApi.Services.Repository;
using ShopApi.Services.SupplierServices;
using ShopApi.Services.UserLoginservices;
using ShopApi.Services.UserServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.AccessControl;
using System.Text;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddScoped<ICustomerServices, CustomerServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ShopDatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ISupplierServices, SupplierServices>();
builder.Services.AddScoped<IOrderServices, OrderSevices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "https://localhost:7277/",
            ValidAudience = "https://localhost:7277/"
        };
    });


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer"
    }) ;
    options.OperationFilter<SecurityRequirementsOperationFilter>();
}
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
