using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("venta")]
    public class Venta
    {     
        public int Id { get; set; }
        [MaxLength(20)]
        public string NroFactura { get; set; }
        public short Establecimiento { get; set; }
        public short PuntoExpedicion { get; set; }
        public int Numero { get; set; }
        public int ClienteId { get; set; }
        public Persona Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public int ColaboradorId { get; set; }
        public Colaborador Vendedor { get; set; }
        public string Observacion { get; set; }
        public short TimbradoId { get; set; }
        [ForeignKey(nameof(TimbradoId))]
        public Timbrado Timbrado { get; set; }
        [MaxLength(1)]
        public string EsAutoimprenta { get; set; }
        [MaxLength(8)]
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public short UsuarioIdRegistro { get; set; }       
        public DateTime? FechaModificacion { get; set; }
        public short? UsuarioIdModificacion { get; set; }       
        public DateTime? FechaAnulacion { get; set; }
        public short? UsuarioIdAnulacion { get; set; }       
        public short EmpresaId { get; set; }
        [ForeignKey(nameof(EmpresaId))]
        public Empresa Empresa { get; set; }
        public IEnumerable<DetalleVenta> DetalleVenta { get; set; }

    }
}
