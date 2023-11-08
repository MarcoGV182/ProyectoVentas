using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Repositorio.IRepositorio;
using System.Diagnostics.CodeAnalysis;

namespace SistemaFacturacionWeb.Repositorio
{
    public class VillaRepositorio : RepositorioGenerico<Villa>, IVillaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public VillaRepositorio(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        
        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.Villas.Update(entidad);
            await Grabar();
            return entidad;
        }
    }
}
