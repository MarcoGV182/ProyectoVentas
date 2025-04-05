using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    public class Rango_Timbrados
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Nro_Establecimiento { get; set; }
        public int Nro_PuntoExp { get; set; }
        public int RangoDesde { get; set; }
        public int RangoHasta { get; set; }
        public int NroActual { get; set; }        
        public short TimbradoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public virtual Timbrado Timbrado { get; set; }

        public int SucursalId { get; set; }
        public virtual Sucursal Sucursal { get; set; }

        public enum TipoDocumento
        {
            Factura = 1,
            NotaCredito = 2,
            NotaDebito = 3,
            Recibo = 4
        }
    }
}
