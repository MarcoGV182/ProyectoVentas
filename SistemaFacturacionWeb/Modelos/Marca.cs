using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionWeb.Modelos
{
    public class Marca
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Marcanro { get; set; }

        public string? Descripcion { get; set; }
        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
