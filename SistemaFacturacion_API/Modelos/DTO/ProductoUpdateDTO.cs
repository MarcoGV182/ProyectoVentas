using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class ProductoUpdateDTO
    {
        [Required]
        public int Articulonro { get; set; }        
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        [MaxLength(150)]
        public string Observacion { get; set; }        
        public string Estado { get; set; }      
        public int TipoimpuestoId { get; set; }
        [MaxLength(50)]
        public string Codigobarra { get; set; }
        public int? Stockminimo { get; set; }        
        public double PrecioCompra { get; set; }
        public DateOnly? Fechavencimiento { get; set; }
        public int? MarcaId { get; set; }
    }
}
