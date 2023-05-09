using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Odonto.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DateContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DateContext") ?? throw new InvalidOperationException("Connection string 'DateContext' not found.")));
builder.Services.AddDbContext<DoctorContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DoctorContext") ?? throw new InvalidOperationException("Connection string 'DoctorContext' not found.")));
builder.Services.AddDbContext<PatientContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PatientContext") ?? throw new InvalidOperationException("Connection string 'PersonContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
