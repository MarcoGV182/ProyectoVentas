using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IUbicacionRepositorio:IRepositorioGenerico<Ubicacion>
    {
        Task<Ubicacion> Actualizar(Ubicacion entidad);

        Task<bool> ValidarUbicacionActiva(int ubicacionId);
    }
}
