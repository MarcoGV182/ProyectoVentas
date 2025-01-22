using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;

namespace SistemaFacturacion_API.Repositorio
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
