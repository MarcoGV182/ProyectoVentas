using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacionWeb.Repositorio
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
