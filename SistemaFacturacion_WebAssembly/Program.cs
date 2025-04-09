using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SistemaFacturacion_WebAssembly;
using SistemaFacturacion_WebAssembly.Services.IServices;
using SistemaFacturacion_WebAssembly.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using MudBlazor.Services;
using Blazored.LocalStorage;
using SistemaFacturacion_WebAssembly.Models;
using Microsoft.AspNetCore.Components.Authorization;
using SistemaFacturacion_WebAssembly.Pages.Mantenimiento.Cliente;
using static SistemaFacturacion_WebAssembly.Services.UsuarioEstadoService;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


#region Agregar cultura predeterminada
// Configurar la cultura predeterminada
var cultureInfo = new CultureInfo("es-ES");
cultureInfo.NumberFormat.NumberGroupSeparator = ".";
cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
#endregion

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
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<ITipoImpuestoService, TipoImpuestoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IPresentacionService, PresentacionService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
builder.Services.AddScoped<ITipoServicioService, TipoServicioService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<ITipoDocIdentidadService, TipoDocIdentidadService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<ITimbradoService, TimbradoService>();
builder.Services.AddScoped<IRangoTimbradoService, RangoTimbradoService>();
builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<UsuarioEstadoService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("RequireOpcionesAccess", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Admin") ||
            (context.User.IsInRole("Jefe") &&
             context.User.HasClaim("Permiso", "Ver Opciones"))
    ));
}); // <- Necesario para manejar la autenticación

await builder.Build().RunAsync();
