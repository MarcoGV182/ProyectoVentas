using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TipoProductoDTO
    {
        public int TipoProductonro { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
    }
}
