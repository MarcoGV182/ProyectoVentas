using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class TipoDocumentoIdentidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Id de la tabla")]
        public short IdTipoDocIdentidad { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
