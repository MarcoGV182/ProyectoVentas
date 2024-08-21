using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class UsuarioCreateDTO
    {  
        public string login { get; set; }       
        public string Password { get; set; }
        public int? ColaboradorId { get; set; } = null;


    }
}
