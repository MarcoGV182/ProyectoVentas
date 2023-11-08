using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacionWeb.Modelos
{
    public class TipoImpuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoimpuestoNro { get; set; }

        [MaxLength(50)]
        [Required]
        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; } = 0;

        public double Baseimponible { get; set; } = 0;
    }
}
