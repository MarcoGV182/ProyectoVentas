using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITipoServicioRepositorio:IRepositorioGenerico<TipoServicio>
    {
        Task<TipoServicio> Actualizar(TipoServicio entidad);
    }
}
