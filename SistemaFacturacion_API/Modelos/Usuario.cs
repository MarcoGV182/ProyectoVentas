using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
    public class Usuario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsuarioId { get; set; }
        [Required]
        public string? Login { get; set; }

        public string? Password { get; set; }        

        public DateTime? Fechaalta { get; set; }

        public DateTime? Fechabaja { get; set; }
        public string Correo { get; set; }
        /*
        public int? Idrol { get; set; }
        public virtual Rol? Rol { get; set; }*/
    }
}
