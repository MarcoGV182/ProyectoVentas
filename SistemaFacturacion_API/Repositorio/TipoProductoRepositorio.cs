using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class TipoProductoRepositorio : RepositorioGenerico<TipoProducto>, ITipoProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TipoProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<TipoProducto> Actualizar(TipoProducto entidad)
        {  
            _db.TipoProducto.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
