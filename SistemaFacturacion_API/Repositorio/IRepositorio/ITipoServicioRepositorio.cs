using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITipoServicioRepositorio:IRepositorioGenerico<TipoServicio>
    {
        Task<TipoServicio> Actualizar(TipoServicio entidad);
    }
}
