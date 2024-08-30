using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class Marca
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Marcanro { get; set; }
        [MaxLength(150)]
        public string Descripcion { get; set; }
    }
}
