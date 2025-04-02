using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    public class DetalleVenta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int IdDetalle { get; set; }
        public int VentaId { get; set; }        
        public int NroItem { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; } = 0;
        [Required]
        public short? TipoimpuestoId { get; set; }
        // Relación polimórfica
        public int ItemId { get; set; }          // FK a ProductoId o ServicioId
        public TipoArticulo TipoItem { get; set; }
        public decimal ImporteIVA { get; set; } = 0;
        public decimal ImporteGravado { get; set; } = 0;
        public decimal ImporteExento { get; set; } = 0;
        public decimal Total { get; set; }


        public virtual Venta Venta { get; set; }
        public virtual TipoImpuesto TipoImpuesto { get; set; }

    }
}
