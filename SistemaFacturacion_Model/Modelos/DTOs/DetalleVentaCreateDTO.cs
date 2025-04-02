using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class DetalleVentaCreateDTO
    {
        public int IdDetalle { get; set; }
        public int NroVenta { get; set; }  
        public int NroItem { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; } = 0;       
        public short? TipoimpuestoId { get; set; }
        public string DescripcionArticulo { get; set; }
        public int ItemId { get; set; }
        public TipoArticulo TipoItem { get; set; } // Enum: Producto = 1, Servicio = 2
        public decimal ImporteIVA { get; set; } = 0;
        public decimal ImporteGravado { get; set; } = 0;
        public decimal ImporteExento { get; set; } = 0;
        public decimal Total { get; set; }
    }
}