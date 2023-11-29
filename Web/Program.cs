using Business.Concrete;
using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStockService, StockManager>();
builder.Services.AddScoped<IStockUnitService, StockUnitManager>();
builder.Services.AddScoped<IStockTypeService, StockTypeManager>();
builder.Services.AddScoped<IStockClassService, StockClassManager>();
builder.Services.AddScoped<ICurrencyService, CurrencyManager>();

builder.Services.AddScoped<IStockDal, EfStockRepository>();
builder.Services.AddScoped<IStockUnitDal, EfStockUnitRepository>();
builder.Services.AddScoped<IStockTypeDal, EfStockTypeRepository>();
builder.Services.AddScoped<IStockClassDal, EfStockClassRepository>();
builder.Services.AddScoped<ICurrencyDal, EfCurrencyRepository>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

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
    pattern: "{controller=Stock}/{action=Index}/{id?}");

app.Run();
