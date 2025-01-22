using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;


namespace SistemaFacturacion_API.Repositorio
{
    public class CiudadRepositorio : RepositorioGenerico<Ciudad>, ICiudadRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CiudadRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Ciudad> Actualizar(Ciudad entidad)
        {  
            _db.Ciudad.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
