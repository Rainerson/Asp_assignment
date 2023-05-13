using Microsoft.EntityFrameworkCore;
using Views.Contexts;
using Views.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // can use dependency injection
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql"))); //activated for dependency injection, lloking for Sql in GetConnectionString in appsettings

builder.Services.AddScoped<ProductService>();

var app = builder.Build();



app.UseHsts();
app.UseHttpsRedirection(); //http to https
app.UseStaticFiles(); // use static www rootfile
                      

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //Go to Home controller and action index

app.Run();
