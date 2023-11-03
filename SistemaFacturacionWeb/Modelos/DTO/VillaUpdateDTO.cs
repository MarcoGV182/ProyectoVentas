using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionWeb.Modelos.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }        
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }
        [Required]
        public int Ocupantes { get; set; }
        public int MetrosCuadratos { get; set; }
        public string ImagenURL { get; set; }
        public string Amenidad { get; set; }
    }
}
