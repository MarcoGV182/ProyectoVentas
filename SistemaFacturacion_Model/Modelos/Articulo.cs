using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("articulo")]
    public abstract class Articulo
    {
        public int ArticuloId { get; set; }
        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        public decimal PrecioBase { get; set; }
        [MaxLength(150)]
        public string Observacion { get; set; }
       
        public string Estado { get; set; }

        public TipoArticulo TipoArticulo { get; set; }

        public DateTime? Fecharegistro { get; set; }

        public DateTime? Fechaultactualizacion { get; set; }

        //Relacion con TipoImpuesto
        public short? TipoimpuestoId { get; set; }

        [ForeignKey(nameof(TipoimpuestoId))]
        public TipoImpuesto TipoImpuesto { get; set; }

        public ICollection<PrecioPromocional> PreciosPromocionales { get; set; }
    }

    public enum TipoArticulo 
    { 
        Servicio,
        Producto    
    }
}
