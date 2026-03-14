using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<HospitalContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDB")));

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();