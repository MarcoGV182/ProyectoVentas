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
        public decimal PrecioBase { get; set; } = 0;       
        public short? TipoimpuestoId { get; set; }
        public string DescripcionArticulo { get; set; }
        public int ArticuloId { get; set; }        
        public decimal ImporteIVA { get; set; } = 0;
        public decimal ImporteGravado { get; set; } = 0;
        public decimal ImporteExento { get; set; } = 0;
        public decimal Total { get; set; }
    }
}