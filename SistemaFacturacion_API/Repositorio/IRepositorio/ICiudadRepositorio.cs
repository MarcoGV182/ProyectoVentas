using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ICiudadRepositorio: IRepositorioGenerico<Ciudad>
    {
        Task<Ciudad> Actualizar(Ciudad entidad);
    }
}
