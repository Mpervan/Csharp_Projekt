using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReceptiBlazor.Client;
using ReceptiBlazor.Client.Services.KategorijaService;
using ReceptiBlazor.Client.Services.KorisnikService;
using ReceptiBlazor.Client.Services.ReceptService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IReceptService, ReceptService>();
builder.Services.AddSingleton<IKategorijaService, KategorijaService>();
builder.Services.AddSingleton<IKorisnikService, KorisnikService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
