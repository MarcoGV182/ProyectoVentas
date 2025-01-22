using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SistemaFacturacion_Model.Modelos
{    
    public class Producto:Articulo
    {
        [MaxLength(50)]
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; } 
        public int Stockactual { get; set; } = 0;
        public decimal PrecioCompra { get; set; } = 0;
        public DateTime? FechaVencimiento { get; set; }

        public short? Idpresentacion { get; set; }
        [ForeignKey(nameof(Idpresentacion))]
        public Presentacion Presentacion { get; set; }

        public int? MarcaId { get; set; }
        [ForeignKey(nameof(MarcaId))]
        public Marca Marca { get; set; }

        public short? CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public CategoriaProducto Categoria { get; set; }

        public short? Unidadmedidanro { get; set; }
        [ForeignKey(nameof(Unidadmedidanro))]
        public UnidadMedida UnidadMedida { get; set; }



    }
}
