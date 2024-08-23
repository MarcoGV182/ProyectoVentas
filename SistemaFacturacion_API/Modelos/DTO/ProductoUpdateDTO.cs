using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class ProductoUpdateDTO
    {
        [Required(ErrorMessage = "La descripcion del Producto es obligatorio"), MaxLength(100)]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        public double Precio { get; set; }

        [MaxLength(150)]
        public string Observacion { get; set; }

        [Required(ErrorMessage = "Ingrese el estado del Producto")]
        public string Estado { get; set; }
        [MaxLength(50)]
        public string Codigobarra { get; set; }

        public int? Stockminimo { get; set; }

        [Required(ErrorMessage = "El precio de compra no puede ser nula")]
        public double PrecioCompra { get; set; }

        public DateOnly? Fechavencimiento { get; set; }
        public short? Idpresentacion { get; set; }
        public int? MarcaId { get; set; }
        public short? TipoproductoId { get; set; }

        public short? Unidadmedidanro { get; set; }
        [Required(ErrorMessage = "El Tipo de Impuesto es requerido")]
        public int TipoimpuestoId { get; set; }

        public DateTime Fechaultactualizacion { get; set; }
    }
}
