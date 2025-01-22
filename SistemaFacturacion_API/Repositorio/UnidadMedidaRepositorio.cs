using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class UnidadMedidaRepositorio : RepositorioGenerico<UnidadMedida>, IUnidadMedidaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UnidadMedidaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<UnidadMedida> Actualizar(UnidadMedida entidad)
        {  
            _db.UnidadMedida.Update(entidad);
            await Grabar();
            return entidad;
        }
    }
}
