using MvcOrder.Interfaces;
using MvcOrder.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services private services to the container.
// Wenn jemand eine IPriceCalculator anfordert, wird eine Instanz von PriceCalculator bereitgestellt.
builder.Services.AddScoped<IPriceCalculator, PriceCalculator>();
// Discount service registration
builder.Services.AddScoped<IDiscountService, BlackFridayDiscountService>();


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
