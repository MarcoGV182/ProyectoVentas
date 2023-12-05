using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IProductoRepositorio:IRepositorioGenerico<Producto>
    {
        Task<Producto> Actualizar(Producto entidad);
    }
}
