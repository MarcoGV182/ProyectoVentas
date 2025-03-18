using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;


namespace SistemaFacturacion_API.Repositorio
{
    public class ClienteRepositorio : RepositorioGenerico<Persona>, IClienteRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ClienteRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Persona> Actualizar(Persona entidad)
        {  
            _db.Persona.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
