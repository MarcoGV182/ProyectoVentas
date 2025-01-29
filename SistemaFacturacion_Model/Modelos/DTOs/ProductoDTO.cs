using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ProductoDTO
    {       
        public int ArticuloId { get; set; }
        [Required(ErrorMessage ="Favor ingrese la Descripcion del Producto")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Favor ingrese el Precio del Producto")]
        public decimal PrecioBase { get; set; }        
        public string Observacion { get; set; }        
        public string Estado { get; set; }     
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; }
        public int Stockactual { get; set; } = 0;
        public decimal PrecioCompra { get; set; } = 0;
        public DateTime? FechaVencimiento { get; set; }
        [Required(ErrorMessage = "Favor seleccione el Impuesto del Producto")]
        public TipoImpuesto TipoImpuesto { get; set; }       
        public Presentacion Presentacion { get; set; }        
        public Marca Marca { get; set; }      
        public CategoriaProducto Categoria { get; set; }       
        public UnidadMedida UnidadMedida { get; set; }

    }
}
