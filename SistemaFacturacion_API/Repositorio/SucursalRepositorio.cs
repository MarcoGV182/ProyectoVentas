using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;
using System.Net;

namespace SistemaFacturacion_API.Repositorio
{
    public class SucursalRepositorio : RepositorioGenerico<Sucursal>, ISucursalRepositorio
    {
        private readonly ApplicationDbContext _db;

        public SucursalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Sucursal> Actualizar(Sucursal entidad)
        {  
            _db.Sucursales.Update(entidad);
            await Grabar();
            return entidad;
        }

        
    }
}
