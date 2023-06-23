using Business.Abstract;
using Business.Concrete;
using Core.UserInfo;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TokenOptions = Core.Utilities.Security.JWT.TokenOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHouseService, HouseManager>();
builder.Services.AddSingleton<IHouseDal, EfHouseDal>();

builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();

builder.Services.AddSingleton<IAddressService, AddressManager>();
builder.Services.AddSingleton<IAddressDal, EfAddressDal>();

builder.Services.AddSingleton<IImageService, ImageManager>();
builder.Services.AddSingleton<IImageDal, EfImageDal>();

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Services.AddSingleton<IFavoriteHouseSerivice, FavoriteHouseManager>();
builder.Services.AddSingleton<IFavoriteHouseDal, EfFavoriteHouseDal>();

builder.Services.AddSingleton<IDistractService, DistractManager>();
builder.Services.AddSingleton<IDistractDal, EfDistractDal>();

builder.Services.AddSingleton<IAuthService, AuthManager>();
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
            
    };
    });
 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("myclients", 
    builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("myclients");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
