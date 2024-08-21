using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
    public class Persona
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nrodocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateOnly? Fechanacimiento { get; set; }
        public string Observacion { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public string LoginRegistro { get; set; }
        public DateTime? Ultfechaactualizacion { get; set; }
        public string LoginActualizacion { get; set; }

      

    }
}
