using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class Ubicacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UbicacionId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
