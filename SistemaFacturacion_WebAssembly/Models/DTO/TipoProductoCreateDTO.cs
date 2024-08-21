using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TipoProductoCreateDTO
    {
        [Required(ErrorMessage ="La descripcion es requerida")]
        public string Descripcion { get; set; }
    }
}
