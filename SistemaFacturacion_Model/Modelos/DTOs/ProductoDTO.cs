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
        public PresentacionDTO Presentacion { get; set; }        
        public MarcaDTO Marca { get; set; }      
        public CategoriaProductoDTO Categoria { get; set; }       
        public UnidadMedidaDTO UnidadMedida { get; set; }

    }
}
