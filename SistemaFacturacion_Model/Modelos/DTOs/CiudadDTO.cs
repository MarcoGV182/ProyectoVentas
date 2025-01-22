using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class CiudadDTO
    {      
        public short CiudadId { get; set; }
        public string Descripcion { get; set; }
    }
}
