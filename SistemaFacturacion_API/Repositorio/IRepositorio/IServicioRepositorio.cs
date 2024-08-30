using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IServicioRepositorio:IRepositorioGenerico<Servicio>
    {
        Task<Servicio> Actualizar(Servicio entidad);
    }
}
