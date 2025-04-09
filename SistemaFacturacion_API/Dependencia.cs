using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Services;
using SistemaFacturacion_API.Mappers;
using Microsoft.AspNetCore.Identity;

namespace SistemaFacturacion_API
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                var setting = configuration.GetSection("ConnectionStrings").Get<ApiSettings>();
                option.UseNpgsql(setting.CadenaSQL);

            });

            services.AddAutoMapper(typeof(MappingConfig).Assembly);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
            services.AddScoped<IAutorizacionService, AutorizacionService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ITipoImpuestoRepositorio, TipoImpuestoRepositorio>();
            services.AddScoped<ICategoriaProductoRepositorio, CategoriaProductoRepositorio>();
            services.AddScoped<IPresentacionRepositorio, PresentacionRepositorio>();
            services.AddScoped<IUnidadMedidaRepositorio, UnidadMedidaRepositorio>();
            services.AddScoped<ITimbradoRepositorio, TimbradoRepositorio>();
            services.AddScoped<IRangoTimbradoRepositorio, RangoTimbradoRepositorio>();
            services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
            services.AddScoped<ITipoServicioRepositorio, TipoServicioRepositorio>();
            services.AddScoped<ICiudadRepositorio, CiudadRepositorio>();
            services.AddScoped<ITipoDocumentoIdentidadRepositorio, TipoDocumentoIdentidadRepositorio>();
            services.AddScoped<IRefreshTokenRepositorio, RefreshTokenRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IVentaRepositorio, VentaRepositorio>();
            services.AddScoped<IUbicacionRepositorio, UbicacionRepositorio>();
            services.AddScoped<ISucursalRepositorio, SucursalRepositorio>();
            services.AddScoped<IStockRepositorio, StockRepositorio>();
            services.AddScoped<SucursalService>();
            services.AddScoped<VentaService>();


            //Configurar el IdentityUser
            services.AddIdentity<Usuario, IdentityRole>(option =>
            {
                option.SignIn.RequireConfirmedAccount = false;
                option.Password.RequireDigit = false;       // No requiere un dígito
                option.Password.RequiredLength = 6;         // Longitud mínima 0
                option.Password.RequireNonAlphanumeric = false; // No requiere caracteres especiales
                option.Password.RequireUppercase = false;   // No requiere mayúsculas
                option.Password.RequireLowercase = false;// No requiere minúsculas
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
