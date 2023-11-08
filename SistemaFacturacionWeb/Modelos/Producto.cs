using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SistemaFacturacionWeb.Modelos
{
    public class Producto:Articulo
    {
        [MaxLength(50)]
        public string? Codigobarra { get; set; }
        public int? Stockminimo { get; set; }
        public int Stockactual { get; set; }        
        public double PrecioCompra { get; set; }
        public DateOnly? Fechavencimiento { get; set; }

        public int? PresentacionId { get; set; }
        [ForeignKey(nameof(PresentacionId))]
        public Presentacion? Presentacion { get; set; }

        public int? MarcaId { get; set; }
        [ForeignKey(nameof(MarcaId))]
        public Marca? Marca { get; set; }

        public short? TipoproductoId { get; set; }
        [ForeignKey(nameof(TipoproductoId))]
        public TipoProducto? TipoProducto { get; set; }
    }
}
