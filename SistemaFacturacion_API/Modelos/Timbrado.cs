using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class Timbrado
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Id de la tabla")]
        public short TimbradoId { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [Required]
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }

        [Comment("Puede ser Autoimprenta Manual Electronico")]
        [Required]
        [MaxLength(15)]
        public string TipoTimbrado { get; set; }
        [Required]
        [MaxLength(1)]
        public string Estado { get; set; }
    }
}
