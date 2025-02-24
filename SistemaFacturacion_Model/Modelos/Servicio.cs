using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{   
    public class Servicio:Articulo
    {
        public short TipoServicioId { get; set; }
        [ForeignKey(nameof(TipoServicioId))]
        public TipoServicio TipoServicio { get; set; }
    }
}
