using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IPresentacionRepositorio:IRepositorioGenerico<Presentacion>
    {
        Task<Presentacion> Actualizar(Presentacion entidad);
    }
}
