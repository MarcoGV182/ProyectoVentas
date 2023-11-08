using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionWeb.Modelos.DTO
{
    public class MarcaCreateDTO
    {
        [Required]
        public string Descripcion { get; set; }
    }
}
