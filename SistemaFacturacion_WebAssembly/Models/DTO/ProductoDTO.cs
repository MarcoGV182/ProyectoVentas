using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class ProductoDTO
    {
        public int Articulonro { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public int? TipoimpuestoId { get; set; }
        public TipoImpuestoDTO TipoImpuesto { get; set; }
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; }
        public int Stockactual { get; set; } = 0;
        public double PrecioCompra { get; set; } = 0;
        public DateOnly? FechaVencimiento { get; set; }
        public short? Idpresentacion { get; set; }
        public PresentacionDTO Presentacion { get; set; }
        public int? MarcaId { get; set; }
        public MarcaDTO Marca { get; set; }
        public short? TipoproductoId { get; set; }
        public TipoProductoDTO TipoProducto { get; set; }



        //public short? Unidadmedidanro { get; set; }
        //public UnidadMedidaDTO UnidadMedida { get; set; }
    }
}
