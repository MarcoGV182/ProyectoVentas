using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacionWeb.Modelos
{
    public class Presentacion
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idpresentacion { get; set; }
        [MaxLength(100)]
        public string? Descripcion { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}
