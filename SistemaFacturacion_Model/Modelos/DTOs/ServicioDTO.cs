using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ServicioDTO:ArticuloDTO
    { 
        public TipoServicio TipoServicio { get; set; } 
    }
}
