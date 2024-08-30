using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class ServicioDTO
    {       
        public int ServicioNro { get; set; }       
        public string Descripcion { get; set; }
        public double Precio { get; set; }        
        public string Observacion { get; set; }        
        public string Estado { get; set; } 
        public TipoImpuesto TipoImpuesto { get; set; }       
        public TipoServicio TipoServicio { get; set; } 
    }
}
