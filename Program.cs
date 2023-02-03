using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.Persistence;
using Microsoft.AspNetCore.Identity;
using ProjectApp.Data;
using ProjectApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();


builder.Services.AddDbContext<AuctionDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDBConnection")));

builder.Services.AddDbContext<ProjectAppIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectAppIdentityContext")));
builder.Services.AddDefaultIdentity<ProjectAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjectAppIdentityContext>();

builder.Services.AddAutoMapper(typeof(Program));

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

app.MapRazorPages();
app.Run();
