using Microsoft.EntityFrameworkCore;
using TestBlazorApp.Application;
using TestBlazorApp.Infrastructure.Data;
using TestBlazorApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Read connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure DbContext using connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)); 

builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
