using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class UnidadMedidaDTO
    {      
        public short UnidadmedidaId { get; set; }

        public string Descripcion { get; set; }
    }
}
