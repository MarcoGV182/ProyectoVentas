using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IPrecioPromocionalRepositorio:IRepositorioGenerico<PrecioPromocional>
    {
        Task<PrecioPromocional> Actualizar(PrecioPromocional entidad);
    }
}
