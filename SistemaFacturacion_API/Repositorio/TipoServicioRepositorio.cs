using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class TipoServicioRepositorio : RepositorioGenerico<TipoServicio>, ITipoServicioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TipoServicioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<TipoServicio> Actualizar(TipoServicio entidad)
        {  
            _db.TipoServicio.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
