using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Repositorio.IRepositorio;

namespace SistemaFacturacionWeb.Repositorio
{
    public class ProductoRepositorio : RepositorioGenerico<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Producto> Actualizar(Producto entidad)
        {
            entidad.Fechaultactualizacion = DateTime.Now;
            _db.Producto.Update(entidad);
            await Grabar();
            return entidad;
        }
    }
}
