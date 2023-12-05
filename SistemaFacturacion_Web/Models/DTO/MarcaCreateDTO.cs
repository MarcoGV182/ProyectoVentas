using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Web.Models.DTO
{
    public class MarcaCreateDTO
    {
        [Required(ErrorMessage ="La descripcion es requerida")]
        public string Descripcion { get; set; }
    }
}
