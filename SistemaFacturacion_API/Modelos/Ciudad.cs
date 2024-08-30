using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class Ciudad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdCiudad { get; set; }
        [MaxLength(200)]
        public string Descripcion { get; set; }
    }
}
