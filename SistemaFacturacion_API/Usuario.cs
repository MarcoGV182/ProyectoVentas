using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API
{
    public class Usuario: IdentityUser
    {
        public int? ColaboradorId { get; set; } // Relación opcional con Persona
        public virtual Colaborador Colaborador { get; set; }
    }
}
