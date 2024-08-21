using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class TipoProducto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TipoProductonro { get; set; }

        public string Descripcion { get; set; }
    }
}
