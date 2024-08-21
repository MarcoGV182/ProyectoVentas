using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class MarcaDTO
    {
        public int Marcanro { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerida")]
        public string Descripcion { get; set; } = null!;
    }
}
