using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
//using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web")));

builder.Services.AddScoped<IGraService, GraService>();

builder.Services.AddAutoMapper(typeof(Web.Configuration.AMProfiles.MainProfile));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();