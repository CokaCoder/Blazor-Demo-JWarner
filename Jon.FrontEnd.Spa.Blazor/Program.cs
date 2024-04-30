using Blazored.LocalStorage;
using Jon.FrontEnd.Spa.Blazor;
using Jon.FrontEnd.Spa.Blazor.Interfaces;
using Jon.FrontEnd.Spa.Blazor.Services;
using Jon.FrontEnd.Spa.Blazor.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<IVehicleDataService, VehicleDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped<ApplicationState>();

builder.Services.AddBlazoredLocalStorage();//In case we want to use later for local caching of results.

await builder.Build().RunAsync();
