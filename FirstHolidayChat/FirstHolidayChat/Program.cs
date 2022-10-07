using FirstHolidayChat.Services;
using FirstHolidayChat.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FirstHolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFConnection")));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHolidayServices, HolidayServices>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
