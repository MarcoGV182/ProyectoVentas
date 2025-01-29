using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_Model.DTOs;
using SistemaFacturacion_Model.Modelos.Custom;

namespace SistemaFacturacion_API.Services
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> GenerarTokenAsync(IdentityUser user);

        Task<string> VerificarTokenAsync(TokenRequest tokenrequest);

    }
}
