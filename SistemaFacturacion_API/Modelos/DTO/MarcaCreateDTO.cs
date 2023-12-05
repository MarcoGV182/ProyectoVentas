using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class MarcaCreateDTO
    {
        [Required]
        public string Descripcion { get; set; }
    }
}
