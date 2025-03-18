using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ServicioCreateDTO
    {
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="El Precio es requerido")]
        public decimal PrecioBase { get; set; }        
        public string Observacion { get; set; }
        [Required(ErrorMessage = "Ingrese el estado del Producto")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "El Tipo de Impuesto es requerido")]
        public int TipoimpuestoId { get; set; }
        public short? TipoServicioId { get; set; }
    }
}
