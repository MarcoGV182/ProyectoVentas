using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class StockRepositorio : RepositorioGenerico<Stock>, IStockRepositorio
    {
        private readonly ApplicationDbContext _db;

        public StockRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Stock> Actualizar(Stock entidad)
        {  
            _db.Stock.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
