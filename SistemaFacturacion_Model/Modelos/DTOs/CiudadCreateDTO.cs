using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class CiudadCreateDTO
    {
        [MaxLength(200)]
        public string Descripcion { get; set; }
    }
}
