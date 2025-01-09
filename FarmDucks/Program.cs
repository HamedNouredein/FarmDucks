using Microsoft.EntityFrameworkCore;
using FarmDucks.Data;
using FarmDucks.Services;
using FarmDucks.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDuckService, DuckService>();
builder.Services.AddScoped<ICycleService, CycleService>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IVaccineService, VaccineService>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<ICycleRepository, CycleRepository>();
builder.Services.AddScoped<IDuckRepository, DuckRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();



builder.Services.AddControllersWithViews();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
