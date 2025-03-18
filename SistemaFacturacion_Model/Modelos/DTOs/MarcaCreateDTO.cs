using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class MarcaCreateDTO
    {
        [Required]
        public string Descripcion { get; set; }
    }
}
