using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_Model.Modelos;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Datos
{
    public class Usuario : IdentityUser
    {
        public int? ColaboradorId { get; set; } // Relación opcional con Persona
        public virtual Colaborador Colaborador { get; set; }
        public int? SucursalId { get; set; } // FK hacia Sucursal
        public virtual Sucursal Sucursal { get; set; } // Propiedad de navegación (opcional)

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; } = new List<IdentityUserRole<string>>();
    }
}
