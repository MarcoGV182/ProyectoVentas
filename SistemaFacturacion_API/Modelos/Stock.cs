using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class Stock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }   
        public int Cantidad { get; set; }

        public DateTime? FechaActualizacion { get; set; }
        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public Producto? Producto { get; set; }

        public int UbicacionId { get; set; }
        [ForeignKey(nameof(UbicacionId))]
        public Ubicacion? Ubicacion { get; set; }
    }
}
