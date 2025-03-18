using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IUnidadMedidaRepositorio:IRepositorioGenerico<UnidadMedida>
    {
        Task<UnidadMedida> Actualizar(UnidadMedida entidad);
    }
}
