using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITipoImpuestoRepositorio:IRepositorioGenerico<TipoImpuesto>
    {
        Task<TipoImpuesto> Actualizar(TipoImpuesto entidad);
    }
}
