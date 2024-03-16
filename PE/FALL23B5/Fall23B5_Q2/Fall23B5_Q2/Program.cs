using Microsoft.EntityFrameworkCore;
using Fall23B5_Q2.Models;
using Fall23B5_Q2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PE_PRN221_Fall23B5Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TachMon"));
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapHub<SignalRHub>("/SignalRHub");

app.MapRazorPages();

app.Run();
