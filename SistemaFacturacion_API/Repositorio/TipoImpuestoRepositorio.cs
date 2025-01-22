using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class TipoImpuestoRepositorio : RepositorioGenerico<TipoImpuesto>, ITipoImpuestoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TipoImpuestoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }        

        public async Task<TipoImpuesto> Actualizar(TipoImpuesto entidad)
        {
            _db.TipoImpuesto.Update(entidad);
            await Grabar();
            return entidad;
        }
    }
}
