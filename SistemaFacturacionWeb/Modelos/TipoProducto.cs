using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionWeb.Modelos
{
    public class TipoProducto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Tiporoductonro { get; set; }

        public string? Descripcion { get; set; }
    }
}
