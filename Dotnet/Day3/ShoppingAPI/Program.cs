using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI.Contexts;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Repositories;
using ShoppingAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string tokenKey = builder.Configuration.GetSection("TokenKey").Value.ToString();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AppCors", opt => { opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
    };
});
builder.Services.AddDbContext<ShoppingCOntext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("shoppingConnection"));
});

builder.Services.AddScoped<IRepository<int,Customer>,CustomerRepository>();
builder.Services.AddScoped<ICustomerAuthentication,CustomerAuthenticationService>();
builder.Services.AddScoped<ITokenService,TokenService>();

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
app.UseCors("AppCors");

app.MapControllers();

app.Run();
