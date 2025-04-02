using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IStockRepositorio
    {
        Task<Stock> ObtenerStockAsync(int productoId, int ubicacionId);
        Task AgregarStockAsync(int productoId, int ubicacionId, int cantidad);
        Task<IEnumerable<Producto>> ObtenerProductosDisponiblesAsync(int ubicacionId);
        Task<int> ObtenerCantidadDisponibleAsync(int productoId, int ubicacionId);
        Task RegistrarMovimientoAsync(MovimientoStock movimiento);
        Task<List<MovimientoStock>> ObtenerMovimientosPorProductoAsync(int productoId, DateTime? desde, DateTime? hasta);
        Task<List<MovimientoStock>> ObtenerMovimientosPorUbicacionAsync(int ubicacionId, DateTime? desde, DateTime? hasta);
    }
}
