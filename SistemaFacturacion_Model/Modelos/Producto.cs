using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{    
    public class Producto:Articulo
    {
        [MaxLength(50)]
        public string Codigobarra { get; set; } = "";
        public int Stockminimo { get; set; }         
        public decimal PrecioCompra { get; set; } = 0;
        public DateTime? FechaVencimiento { get; set; }

        public short? PresentacionId { get; set; }
        [ForeignKey(nameof(PresentacionId))]
        public virtual Presentacion Presentacion { get; set; }

        public int? MarcaId { get; set; }
        [ForeignKey(nameof(MarcaId))]
        public virtual Marca Marca { get; set; }

        public short? CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public virtual CategoriaProducto Categoria { get; set; }

        public short? UnidadMedidaId { get; set; }
        [ForeignKey(nameof(UnidadMedidaId))]
        public virtual UnidadMedida UnidadMedida { get; set; }

        // Relación con stock
        public virtual ICollection<Stock> Stocks { get; set; }



    }
}
