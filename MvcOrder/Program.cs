using MvcOrder.Interfaces;
using MvcOrder.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services private services to the container.
// Wenn jemand eine IPriceCalculator anfordert, wird eine Instanz von PriceCalculator bereitgestellt.
builder.Services.AddTransient<IPriceCalculator, PriceCalculator>();
// builder.Services.AddScoped<IPriceCalculator, PriceCalculator>();
// Discount service registration
builder.Services.AddScoped<IDiscountService, BlackFridayDiscountService>();

// bei Singleton wird alles in dieselbe Log-Instanz geschrieben
// builder.Services.AddSingleton<IRequestLog, RequestLog>();

// bei Transient lebt der Log pro "Verwendung", d.h. einmal im Controller
// und einmal im Service, aber auch NUR für einen Aufruf
// builder.Services.AddTransient<IRequestLog, RequestLog>();

// Service lebt über die Lebensdauer eines Requests (inkl. Redirection)
// und auch, wenn RequestLog sowohl vom Controller, als auch vom PaymentService
// genutzt wird. 
builder.Services.AddScoped<IRequestLog, RequestLog>();
builder.Services.AddScoped<PaymentService>();


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
