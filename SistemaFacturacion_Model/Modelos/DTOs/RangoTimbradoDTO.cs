
namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class RangoTimbradoDTO
    {
        public int Id { get; set; }
        public int Nro_Establecimiento { get; set; }
        public int Nro_PuntoExp { get; set; }
        public int RangoDesde { get; set; }
        public int RangoHasta { get; set; }
        public int NroActual { get; set; }
        public TimbradoDTO Timbrado { get; set; }
        public TipoDocumento TipoDocumentoId { get; set; }
        public SucursalDTO Sucursal { get; set; }
    }
}
