using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class ProductoDTO
    {       
        public int Articulonro { get; set; }       
        public string Descripcion { get; set; }
        public double Precio { get; set; }        
        public string Observacion { get; set; }        
        public string Estado { get; set; }     
        public string Codigobarra { get; set; }
        public int Stockminimo { get; set; }
        public int Stockactual { get; set; } = 0;
        public double PrecioCompra { get; set; } = 0;
        public DateOnly? FechaVencimiento { get; set; }
        public int? TipoimpuestoNro { get; set; }
        public string TipoImpuestoDescripcion { get; set; }
        public double Porcentajeiva { get; set; } = 0;
        public double Baseimponible { get; set; } = 0;
        public int? Idpresentacion { get; set; }
        public string PresentacionDescripcion { get; set; }
        public int? Marcanro { get; set; }
        public string MarcaDescripcion { get; set; }
        public short? TipoProductonro { get; set; }
        public string TipoProductoDescripcion { get; set; }
        public short? Unidadmedidanro { get; set; }
        public string UMDescripcion { get; set; }

    }
}
