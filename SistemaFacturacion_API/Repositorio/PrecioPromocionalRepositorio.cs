using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class PrecioPromocionalRepositorio : RepositorioGenerico<PrecioPromocional>, IPrecioPromocionalRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PrecioPromocionalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<PrecioPromocional> Actualizar(PrecioPromocional entidad)
        {  
            _db.PrecioPromocional.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
