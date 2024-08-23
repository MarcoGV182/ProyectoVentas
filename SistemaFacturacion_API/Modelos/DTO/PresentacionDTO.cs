using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class PresentacionDTO
    {
        public int Idpresentacion { get; set; }

        public string Descripcion { get; set; }      
    }
}
