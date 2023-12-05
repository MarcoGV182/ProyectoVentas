using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITipoImpuestoRepositorio:IRepositorioGenerico<TipoImpuesto>
    {
        Task<TipoImpuesto> Actualizar(TipoImpuesto entidad);
    }
}
