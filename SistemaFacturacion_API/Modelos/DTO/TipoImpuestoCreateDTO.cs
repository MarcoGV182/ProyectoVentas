using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class TipoImpuestoCreateDTO
    {      
        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; }

        public double Baseimponible { get; set; }
    }
}
