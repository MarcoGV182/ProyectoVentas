using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class TipoImpuestoDTO
    {
        public short TipoimpuestoId { get; set; }

        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; }

        public double Baseimponible { get; set; }
    }
}
