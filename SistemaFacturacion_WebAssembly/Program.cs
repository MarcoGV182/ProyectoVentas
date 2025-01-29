using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SistemaFacturacion_WebAssembly;
using SistemaFacturacion_WebAssembly.Services.IServices;
using SistemaFacturacion_WebAssembly.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using MudBlazor.Services;
using Blazored.LocalStorage;
using SistemaFacturacion_WebAssembly.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("Facturacion", client =>
{
    client.BaseAddress = new Uri("https://localhost:7001");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    // Puedes agregar más configuraciones aquí, como políticas de reintento
})
    .AddHttpMessageHandler<AuthTokenHandler>();
builder.Services.AddTransient<AuthTokenHandler>();

//Inyectar dependencias
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<ITipoImpuestoService, TipoImpuestoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IPresentacionService, PresentacionService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
builder.Services.AddScoped<ITipoServicioService, TipoServicioService>();

builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
