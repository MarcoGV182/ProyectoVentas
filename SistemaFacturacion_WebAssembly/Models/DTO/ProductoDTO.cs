using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class ProductoDTO
    {
        public int Articulonro { get; set; }
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el Precio de Venta")]
        public double Precio { get; set; }
        public string Observacion { get; set; }

        [Required(ErrorMessage = "Ingrese el estado del Producto")]
        public string Estado { get; set; }
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; }
        public int Stockactual { get; set; } = 0;
        public double PrecioCompra { get; set; } = 0;
        public DateTime? FechaVencimiento { get; set; } = DateTime.Today;
        public TipoImpuestoDTO TipoImpuesto { get; set; }
        public PresentacionDTO Presentacion { get; set; }
        public MarcaDTO Marca { get; set; }
        public TipoProductoDTO TipoProducto { get; set; }
        public UnidadMedidaDTO UnidadMedida { get; set; }
    }
}
