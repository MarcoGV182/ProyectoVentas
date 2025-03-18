using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IRefreshTokenRepositorio:IRepositorioGenerico<RefreshToken>
    {
        Task<RefreshToken> Actualizar(RefreshToken entidad);
    }
}
