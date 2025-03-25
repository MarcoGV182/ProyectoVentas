using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IStockRepositorio:IRepositorioGenerico<Stock>
    {
        Task<Stock> Actualizar(Stock entidad);
    }
}
