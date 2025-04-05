using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ProductoDTO:ArticuloDTO
    {                
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; }        
        public decimal PrecioCompra { get; set; } = 0;
        public DateTime? FechaVencimiento { get; set; }
        public Presentacion Presentacion { get; set; }        
        public Marca Marca { get; set; }      
        public CategoriaProducto Categoria { get; set; }       
        public UnidadMedida UnidadMedida { get; set; }

    }
}
