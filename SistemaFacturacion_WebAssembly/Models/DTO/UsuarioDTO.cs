using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Login { get; set; }       
        public string? Correo { get; set; }
        //public Colaborador Colaborador { get; set; }
    }
}
