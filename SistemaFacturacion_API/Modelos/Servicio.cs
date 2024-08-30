using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
    public class Servicio:Articulo
    {
        public short TipoServicoNro { get; set; }
        [ForeignKey(nameof(TipoServicoNro))]
        public TipoServicio TipoServicio { get; set; }
    }
}
