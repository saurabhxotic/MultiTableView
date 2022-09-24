using MultiTableView.Models;
using MultiTableView.Repos;
using MultiTableView.BussinessLayer;
using MultiTableView.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<AppSettings>(
builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddTransient<db>();
builder.Services.AddTransient<EmployeeBL>();
builder.Services.AddTransient<EmployeeDL>();

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
