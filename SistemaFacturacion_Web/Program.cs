using SistemaFacturacion_Web;
using SistemaFacturacion_Web.Services;
using SistemaFacturacion_Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddHttpClient<IMarcaService, MarcaService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddHttpClient<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoService, ProductoService>();


builder.Services.AddHttpClient<ITipoImpuestoService, TipoImpuestoService>();
builder.Services.AddScoped<ITipoImpuestoService, TipoImpuestoService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
