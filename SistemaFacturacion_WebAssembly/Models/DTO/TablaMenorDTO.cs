using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TablaMenorDTO
    {
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
    }
}
