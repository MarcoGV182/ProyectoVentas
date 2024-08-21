using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITipoProductoRepositorio:IRepositorioGenerico<TipoProducto>
    {
        Task<TipoProducto> Actualizar(TipoProducto entidad);
    }
}
