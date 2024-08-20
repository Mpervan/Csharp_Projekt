using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ReceptiAplikacija.Data;
using ReceptiAplikacija.Services.ReceptService;
using ReceptiAplikacija.Services.KategorijaService;
using ReceptiAplikacija.Services.KorisnikService;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using ReceptiAplikacija;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ReceptService>();
builder.Services.AddSingleton<IReceptService, ReceptService>();
builder.Services.AddSingleton<IKategorijaService, KategorijaService>();
builder.Services.AddSingleton<IKorisnikService, KorisnikService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddOptions();
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
