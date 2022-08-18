using ProjetHotel.Infrastructure;
using ProjetHotelBLL.Services;
using ProjetHotelDAL.Interfaces;
using ProjetHotelDAL.Repositories;
using System.Data.SqlClient;
using Tools.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Config Injection
// - Tools
builder.Services.AddTransient<Connection>((service) =>
{
    return new Connection(
        SqlClientFactory.Instance,
        builder.Configuration.GetConnectionString("Default")
    );
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<SessionManager>();
// - DAL
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

// - BLL
builder.Services.AddTransient<ClientService>();
builder.Services.AddTransient<HotelService>();
builder.Services.AddTransient<ReservationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
