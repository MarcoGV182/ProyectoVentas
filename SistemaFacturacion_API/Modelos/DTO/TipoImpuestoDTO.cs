using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class TipoImpuestoDTO
    {
        public int TipoimpuestoNro { get; set; }

        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; }

        public double Baseimponible { get; set; }
    }
}
