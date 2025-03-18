using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("empresa")]
    public class Empresa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short EmpresaId { get; set; }
        [MaxLength(150)]
        public string Denominacion { get; set; }
        [MaxLength(15)]
        public string RUC { get; set; }
        public byte[] Logo { get; set; }
        [MaxLength(1)]
        public string Estado { get; set; }
    }
}
