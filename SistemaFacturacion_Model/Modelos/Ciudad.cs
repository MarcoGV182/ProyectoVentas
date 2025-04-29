using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("ciudad")]
    public class Ciudad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CiudadId { get; set; }
        
        [Required,MaxLength(200)]
        public string Descripcion { get; set; }
    }
}
