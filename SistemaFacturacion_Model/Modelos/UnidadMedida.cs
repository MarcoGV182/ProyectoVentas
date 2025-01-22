using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("unidadmedida")]
    public class UnidadMedida
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short UnidadMedidaId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Producto>  Productos { get; set; }
    }
}
