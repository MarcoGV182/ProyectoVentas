using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("tipodocumentoidentidad")]
    public class TipoDocumentoIdentidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public short Id { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
