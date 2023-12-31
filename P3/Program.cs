using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P3.Areas.Identity.Data;
using P3.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("P3ContextConnection") ?? throw new InvalidOperationException("Connection string 'P3ContextConnection' not found.");

builder.Services.AddDbContext<P3Context>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<P3User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<P3Context>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
