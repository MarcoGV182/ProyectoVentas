using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IPresentacionRepositorio:IRepositorioGenerico<Presentacion>
    {
        Task<Presentacion> Actualizar(Presentacion entidad);
    }
}
