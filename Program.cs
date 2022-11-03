using MySql.Data.MySqlClient;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Repos;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("PokeDex"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IDexRepo, DexRepo>();
builder.Services.AddTransient<IPartyRepo, PartyRepo>();
builder.Services.AddTransient<IAdventureRepo, AdventureRepo>();

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
