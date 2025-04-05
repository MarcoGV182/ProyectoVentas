using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos.Custom;

namespace SistemaFacturacion_API.Services
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> GenerarTokenAsync(Usuario user);

        Task<string> VerificarTokenAsync(TokenRequest tokenrequest);

    }
}
