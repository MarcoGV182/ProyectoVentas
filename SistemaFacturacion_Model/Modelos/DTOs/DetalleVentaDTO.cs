using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class DetalleVentaDTO
    {   
        public int IdDetalle { get; set; }
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        public int NroItem { get; set; }
        public decimal Cantidad { get; set; }
        public double Precio { get; set; } = 0; 
        public TipoImpuesto TipoImpuesto { get; set; }
        public Articulo Articulo { get; set; }
        public decimal ImporteIVA { get; set; } = 0;
        public decimal ImporteGravado { get; set; } = 0;
        public decimal ImporteExento { get; set; } = 0;
        public decimal Total { get; set; }
    }
}
