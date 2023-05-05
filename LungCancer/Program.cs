using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.DbContextDir;
using LungCancer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("SqlCon");
builder.Services.AddDbContext<LungCancerContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<LungsInterface<User>, Users_Repo>();
builder.Services.AddScoped<LungsInterface<Prescription>, Prescription_Repo>();
builder.Services.AddScoped<LungsInterface<Prediction>, Prediction_Repo>();

builder.Services.AddScoped<LungsInterface<Image>, Images_Repo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
