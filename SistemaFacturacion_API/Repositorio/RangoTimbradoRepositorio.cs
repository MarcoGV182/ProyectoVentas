using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;


namespace SistemaFacturacion_API.Repositorio
{
    public class RangoTimbradoRepositorio : RepositorioGenerico<Rango_Timbrados>, IRangoTimbradoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public RangoTimbradoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Rango_Timbrados> Actualizar(Rango_Timbrados entidad)
        {
            _db.Rango_Timbrados.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
