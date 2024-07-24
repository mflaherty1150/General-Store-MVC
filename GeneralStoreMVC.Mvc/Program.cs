using GeneralStoreMVC.Data;
using GeneralStoreMVC.Models.AutoMap;
using GeneralStoreMVC.Services.CustomerServices;
using GeneralStoreMVC.Services.ProductServices;
using GeneralStoreMVC.Services.TransactionServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GeneralStoreDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("GeneralStoreLocalDb")
));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddAutoMapper(typeof(CustomerMapProfile));
builder.Services.AddAutoMapper(typeof(ProductMapProfile));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
