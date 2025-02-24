using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("tipoimpuesto")]
    public class TipoImpuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TipoimpuestoId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Descripcion { get; set; }

        public decimal Porcentajeiva { get; set; } = 0;

        public decimal Baseimponible { get; set; } = 0;
    }
}
