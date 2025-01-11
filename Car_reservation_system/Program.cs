using Car_reservation_system;
using Car_reservation_system.Controllers;
using Car_reservation_system.Middleware;
using Car_reservation_system.Repositories;
using Car_reservation_system.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/";
    });

builder.Services.AddDbContext<CarRentalManagerContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalDbConnection")));

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CarRentalSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


var app = builder.Build();

// Configure the HTTP request pipeline.

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<CarRentalSeeder>();
seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/Home/Home/Error?statusCode={0}");

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}");

app.Run();
