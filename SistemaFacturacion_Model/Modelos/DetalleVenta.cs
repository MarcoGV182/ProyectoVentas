using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    public class DetalleVenta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int IdDetalle { get; set; }
        public int NroVenta { get; set; }
        [ForeignKey(nameof(NroVenta))]
        public Venta Venta { get; set; }
        public int NroItem { get; set; }
        public decimal Cantidad { get; set; }
        public double Precio { get; set; } = 0;
        [Required]
        public short? TipoimpuestoId { get; set; }
        [ForeignKey(nameof(TipoimpuestoId))]
        public TipoImpuesto TipoImpuesto { get; set; }
        public int ArticuloId { get; set; }
        [ForeignKey(nameof(ArticuloId))]
        public Articulo Articulo { get; set; }
        public decimal ImporteIVA { get; set; } = 0;
        public decimal ImporteGravado { get; set; } = 0;
        public decimal ImporteExento { get; set; } = 0;
        public decimal Total { get; set; }

    }
}
