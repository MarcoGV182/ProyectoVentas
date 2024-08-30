using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short UsuarioId { get; set; }
        [Required]
        public string Login { get; set; } = null;
        [Required]
        public string Password { get; set; } = null;   
        public DateTime? Fechaalta { get; set; }
        public DateTime? Fechabaja { get; set; }
        public string Estado { get; set; }
        public int? ColaboradorId { get; set; }//Clave externa opcional con colaborador
        public Colaborador Colaborador { get; set; }//Relacion opcional       
    }
}
