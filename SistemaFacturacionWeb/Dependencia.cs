using Microsoft.EntityFrameworkCore;
using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Repositorio.IRepositorio;
using SistemaFacturacionWeb.Repositorio;


namespace SistemaFacturacionWeb
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("CadenaSQL"));

            });

            services.AddAutoMapper(typeof(MappingConfig));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IVillaRepositorio, VillaRepositorio>();
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
        }
    }
}
