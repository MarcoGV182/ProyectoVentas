using SistemaFacturacionWeb.Modelos;

namespace SistemaFacturacionWeb.Repositorio.IRepositorio
{
    public interface IProductoRepositorio:IRepositorioGenerico<Producto>
    {
        Task<Producto> Actualizar(Producto entidad);
    }
}
