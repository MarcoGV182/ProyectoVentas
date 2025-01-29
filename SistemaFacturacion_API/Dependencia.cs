using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Services;

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
            services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
            services.AddScoped<ITipoServicioRepositorio, TipoServicioRepositorio>();
            services.AddScoped<ICiudadRepositorio, CiudadRepositorio>();
            services.AddScoped<ITipoDocumentoIdentidadRepositorio, TipoDocumentoIdentidadRepositorio>();
            services.AddScoped<IRefreshTokenRepositorio, RefreshTokenRepositorio>();
        }
    }
}
