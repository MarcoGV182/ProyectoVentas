namespace SistemaFacturacion_API.Modelos
{
    public class Servicio:Articulo
    {
        public short TipoServicoNro { get; set; }
        public TipoServicio TipoServicio { get; set; }
    }
}
