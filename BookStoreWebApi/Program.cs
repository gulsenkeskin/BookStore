using Microsoft.EntityFrameworkCore;
using BookStoreWebApi.DbOperations;
using System.Reflection;
using BookStoreWebApi.Middlewares;
using BookStoreWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //token'ı kimler kullanabilir
        ValidateAudience = true,
        //token ın dağıtıcısı
        ValidateIssuer = true,
        ValidateLifetime = true,
        //token ı imzalayacağımız key i kontrol et
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        //token ı üreten sunucunun timezone u ile token ı kullanan clientların time zonu birbirinden farklı olduğunda , token in expiration date inin üzerine burda verilen zaman eklenir
        ClockSkew = TimeSpan.Zero,
    };
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
builder.Services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<BookStoreDbContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseCustomExceptionMiddleware();

app.Run();
