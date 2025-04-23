using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ProductoCreateDTO
    {   
        [Required(ErrorMessage ="La descripcion del Producto es obligatorio"),MaxLength(100)]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage ="El precio del producto es obligatorio")]
        public decimal PrecioBase { get; set; }

        [MaxLength(150)]
        public string Observacion { get; set; }

        [Required(ErrorMessage ="Seleccione el estado del Producto")]
        public string Estado { get; set; }
        [MaxLength(50)]
        public string Codigobarra { get; set; }

        public int? Stockminimo { get; set; }

        [Required(ErrorMessage = "El precio de compra no puede ser nula")]
        public decimal PrecioCompra { get; set; }

        public DateTime? FechaVencimiento { get; set; }
        public short? PresentacionId { get; set; }
        public int? MarcaId { get; set; }
        public short? CategoriaId { get; set; }      

        public short? UnidadMedidaId { get; set; }
        [Required(ErrorMessage = "El Tipo de Impuesto es requerido")]
        public short TipoimpuestoId { get; set; }      

        public DateTime? Fecharegistro { get; set; }

        // Relación con stock
        public virtual ICollection<StockAddDTO> Stocks { get; set; }


    }
}
