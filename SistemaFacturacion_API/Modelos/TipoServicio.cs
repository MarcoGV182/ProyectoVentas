using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class TipoServicio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TipoServicoNro { get; set; }

        public string Descripcion { get; set; }
    }
}
