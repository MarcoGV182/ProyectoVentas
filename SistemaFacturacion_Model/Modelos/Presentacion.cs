using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("presentacion")]
    public class Presentacion
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short PresentacionId { get; set; }
        [Required, MaxLength(200)]
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
