using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("articulo")]
    public abstract class Articulo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticuloId { get; set; }
        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        public decimal PrecioBase { get; set; }
        [MaxLength(150)]
        public string Observacion { get; set; }

        public string Estado { get; set; } = "A";

        public TipoArticulo TipoArticulo { get; set; }

        public DateTime? Fecharegistro { get; set; }

        public DateTime? Fechaultactualizacion { get; set; }

        //Relacion con TipoImpuesto
        public short? TipoimpuestoId { get; set; }

        [ForeignKey(nameof(TipoimpuestoId))]
        public TipoImpuesto TipoImpuesto { get; set; }
        public int? SucursalId { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    
    }

    public enum TipoArticulo
    {
        Producto = 1,
        Servicio = 2
    }
}
