using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Web.Models.DTO
{
    public class MarcaDTO
    {
        public int Marcanro { get; set; }
        public string Descripcion { get; set; }
    }
}
