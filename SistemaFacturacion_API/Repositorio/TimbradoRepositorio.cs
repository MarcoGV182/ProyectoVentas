using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SistemaFacturacion_API.Repositorio
{
    public class TimbradoRepositorio : RepositorioGenerico<Timbrado>, ITimbradoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TimbradoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Timbrado> ActualizarAsync(Timbrado entidad)
        {  
            _db.Timbrado.Update(entidad);
            await Grabar();
            return entidad;
        }

        public bool ExisteTimbradoAsync(short id)
        {
            return _db.Timbrado.Any(e => e.TimbradoId == id);
        }

     

    }
}
