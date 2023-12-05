using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class MarcaRepositorio : RepositorioGenerico<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Marca> Actualizar(Marca entidad)
        {  
            _db.Marca.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
