using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TipoImpuestoCreateDTO
    {
        [Required(ErrorMessage = "La Descripcion es requerida.")]
        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; } = 0;

        public double Baseimponible { get; set; } = 0;
    }
}
