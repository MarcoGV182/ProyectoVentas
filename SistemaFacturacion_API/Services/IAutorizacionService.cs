using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_Model.Modelos.Custom;

namespace SistemaFacturacion_API.Services
{
    public interface IAutorizacionService
    {
        string GenerarToken(IdentityUser user);

    }
}
