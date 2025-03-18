using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class TimbradoDTO
    {       
        public short TimbradoId { get; set; }      
        public string Numero { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
        public string TipoTimbrado { get; set; }       
        public string Estado { get; set; }
    }
}
