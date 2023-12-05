using SistemaFacturacion_API.Modelos.Custom;

namespace SistemaFacturacion_API.Services
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);

        Task<AutorizacionResponse> DevolverRefrestToken(RefreshTokenRequest refrestToken,int idUsuario);

    }
}
