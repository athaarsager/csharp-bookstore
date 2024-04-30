using Microsoft.EntityFrameworkCore;
using csharp_bookstore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// *** This segment is the only block of code I added to this file
// Everything else was automatically generated boilerplate

string DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL_STR");
string connectionString = DATABASE_URL ?? builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Using connection string: {connectionString}");

// Have to install PostreSQL using NuGet
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(connectionString)
);

// ***

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
