using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class TipoDocumentoIdentidadRepositorio : RepositorioGenerico<TipoDocumentoIdentidad>, ITipoDocumentoIdentidadRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TipoDocumentoIdentidadRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<TipoDocumentoIdentidad> Actualizar(TipoDocumentoIdentidad entidad)
        {  
            _db.TipoDocumentoIdentidad.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
