using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SistemaFacturacion_API.Modelos
{
    public class Producto:Articulo
    {
        [MaxLength(50)]
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; } 
        public int Stockactual { get; set; } = 0;
        public double PrecioCompra { get; set; } = 0;
        public DateOnly? FechaVencimiento { get; set; }

        public short? Idpresentacion { get; set; }
        [ForeignKey(nameof(Idpresentacion))]
        public Presentacion Presentacion { get; set; }

        public int? MarcaId { get; set; }
        [ForeignKey(nameof(MarcaId))]
        public Marca Marca { get; set; }

        public short? TipoproductoId { get; set; }
        [ForeignKey(nameof(TipoproductoId))]
        public TipoProducto TipoProducto { get; set; }

        public short? Unidadmedidanro { get; set; }
        [ForeignKey(nameof(Unidadmedidanro))]
        public UnidadMedida UnidadMedida { get; set; }


    }
}
