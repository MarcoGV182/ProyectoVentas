using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class PresentacionDTO
    {
        public short PresentacionId { get; set; }

        public string Descripcion { get; set; }      
    }
}
