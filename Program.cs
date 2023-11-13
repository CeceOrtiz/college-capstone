using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using D424.Data;
using D424.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<D424Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("D424Context") ?? throw new InvalidOperationException("Connection string 'D424Context' not found.")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<D424Context>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "User",
        areaName: "User",
        pattern: "User/{controller=Dashboard}/{action=Index}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "Login",
        pattern: "{controller=Account}/{action=Index}/{id?}");
}
);
#pragma warning restore ASP0014

app.Run();
