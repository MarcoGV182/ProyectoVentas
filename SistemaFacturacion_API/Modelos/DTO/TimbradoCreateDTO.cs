using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class TimbradoCreateDTO
    {   
        [Required]
        public string Numero { get; set; }
        [Required]
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
        public TipoTimbradoEnum TipoTimbrado { get; set; }  
    }

    public enum TipoTimbradoEnum
    {
        Manual,
        Automprenta,
        Electronico
    }
}
