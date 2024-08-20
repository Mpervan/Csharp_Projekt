using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReceptiNoviApp.Client;
using ReceptiNoviApp.Client.Services.KategorijaServices;
using ReceptiNoviApp.Client.Services.KorisnikServices;
using ReceptiNoviApp.Client.Services.RecenzijaService;
using ReceptiNoviApp.Client.Services.ReceptServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IReceptService, ReceptService>();
builder.Services.AddScoped<IKategorijaService, KategorijaService>();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddScoped<IRecenzijaService, RecenzijaService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
