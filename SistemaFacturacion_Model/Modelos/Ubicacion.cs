using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("ubicacion")]
    public class Ubicacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UbicacionId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [Required]
        public bool Activa { get; set; } = true; 
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public int SucursalId { get; set; }

        // Relación con stock
        public virtual ICollection<Stock> Stocks { get; set; }
        // Relación con sucursal
        [ForeignKey(nameof(SucursalId))]
        public virtual Sucursal Sucursal { get; set; }

    }
}
