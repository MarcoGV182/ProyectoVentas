using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class TimbradoRepositorio : RepositorioGenerico<Timbrado>, ITimbradoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TimbradoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Timbrado> Actualizar(Timbrado entidad)
        {  
            _db.Timbrado.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
