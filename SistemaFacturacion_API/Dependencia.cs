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
                option.UseNpgsql(configuration.GetConnectionString("CadenaSQL"));

            });

            services.AddAutoMapper(typeof(MappingConfig).Assembly);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
            services.AddScoped<IAutorizacionService, AutorizacionService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ITipoImpuestoRepositorio, TipoImpuestoRepositorio>();
            services.AddScoped<ITipoProductoRepositorio, TipoProductoRepositorio>();
            services.AddScoped<IPresentacionRepositorio, PresentacionRepositorio>();
        }
    }
}
