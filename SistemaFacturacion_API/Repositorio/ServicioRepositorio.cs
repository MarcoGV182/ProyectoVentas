using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class ServicioRepositorio : RepositorioGenerico<Servicio>, IServicioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ServicioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Servicio> Actualizar(Servicio entidad)
        {  
            _db.Servicio.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
