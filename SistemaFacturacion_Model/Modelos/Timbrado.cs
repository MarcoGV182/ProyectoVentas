using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("timbrado")]
    public class Timbrado
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public short TimbradoId { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [Required]
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime? FechaFinVigencia { get; set; }       
        [Required]
        [MaxLength(15)]
        public string TipoTimbrado { get; set; }
        [Required]
        [MaxLength(1)]
        public string Estado { get; set; }

        
        public virtual ICollection<Rango_Timbrados> Rango_Timbrados { get; set; }
    }
}
