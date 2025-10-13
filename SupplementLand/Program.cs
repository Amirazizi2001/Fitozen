using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using SupplementLand.Infrastructure;
using SupplementLand.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Scoped
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICatService, CatService>();
builder.Services.AddScoped<IFactoryService, FactoryService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IRateService, RateService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IDocumentService, DocumentService>();    




//Dbcontext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SupplementLandDb>(options =>
options.UseSqlServer(connectionString));
//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    // بخوان از کوکی به جای Header
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("access_token"))
            {
                context.Token = context.Request.Cookies["access_token"];
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();


//if (app.Environment.IsDevelopment())
//{
//app.UseDeveloperExceptionPage();
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.MapControllers();

app.Run();