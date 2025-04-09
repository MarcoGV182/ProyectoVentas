using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class RangoTimbradoCreateDTO
    {
        [Required]
        public int Nro_Establecimiento { get; set; }
        [Required]
        public int Nro_PuntoExp { get; set; }
        [Required]
        public int RangoDesde { get; set; }
        [Required]
        public int RangoHasta { get; set; }
        [Required]
        public short TimbradoId { get; set; }
        [Required]
        public TipoDocumento TipoDocumentoId { get; set; }
        [Required]
        public int SucursalId { get; set; }
    }
}
