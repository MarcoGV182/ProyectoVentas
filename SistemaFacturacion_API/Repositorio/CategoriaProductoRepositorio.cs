using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class CategoriaProductoRepositorio : RepositorioGenerico<CategoriaProducto>, ICategoriaProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CategoriaProducto> Actualizar(CategoriaProducto entidad)
        {  
            _db.CategoriaProducto.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
