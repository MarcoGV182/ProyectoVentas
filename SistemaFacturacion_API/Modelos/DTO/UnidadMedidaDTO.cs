using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class UnidadMedidaDTO
    {      
        public short Unidadmedidanro { get; set; }

        public string Descripcion { get; set; }
    }
}
