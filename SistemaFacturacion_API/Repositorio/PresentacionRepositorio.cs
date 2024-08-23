using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class PresentacionRepositorio : RepositorioGenerico<Presentacion>, IPresentacionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PresentacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Presentacion> Actualizar(Presentacion entidad)
        {  
            _db.Presentacion.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
