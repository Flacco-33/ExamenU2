using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ExamenU2.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ControlConsumoAguaContext>(opciones =>
	opciones.UseSqlServer(builder.Configuration.GetConnectionString("AguaDB"))
);
builder.Services.AddSignalR();

builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme
).AddCookie(opciones=>
{
	opciones.LoginPath = new PathString("/Usuario/Login");
	opciones.AccessDeniedPath = new PathString("/Usuario/NoPermitido");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
