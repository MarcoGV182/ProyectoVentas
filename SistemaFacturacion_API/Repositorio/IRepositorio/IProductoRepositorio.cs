using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IProductoRepositorio:IRepositorioGenerico<Producto>
    {
        Task<Producto> Actualizar(Producto entidad);
    }
}
