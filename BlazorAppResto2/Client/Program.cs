global using BlazorAppResto2.Client.Services.EstadoProductoService;
global using BlazorAppResto2.Client.Services.CategoriaProductoService;
global using BlazorAppResto2.Client.Services.ProductosServices;
global using BlazorAppResto2.Shared.Models;
using BlazorAppResto2.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEstadoProductoService, EstadoProductoService>();
builder.Services.AddScoped<ICategoriaProductoService, CategoriaProductoService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
await builder.Build().RunAsync();
