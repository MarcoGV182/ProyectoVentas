using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ICategoriaProductoRepositorio:IRepositorioGenerico<CategoriaProducto>
    {
        Task<CategoriaProducto> Actualizar(CategoriaProducto entidad);
    }
}
