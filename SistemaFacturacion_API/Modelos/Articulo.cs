using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
    public class Articulo
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Id de la tabla")]
        public int Articulonro { get; set; }
        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        public double Precio { get; set; }
        [MaxLength(150)]
        public string Observacion { get; set; }

        [MaxLength(150),Comment("Estado del Producto,Servicio")]
        public string Estado { get; set; }

        public TipoArticulo? Tipoarticulo { get; set; }

        public DateTime? Fecharegistro { get; set; }

        public DateTime? Fechaultactualizacion { get; set; }


        //Relacion con TipoImpuesto
        public int? TipoimpuestoId { get; set; }

        [ForeignKey(nameof(TipoimpuestoId))]
        public TipoImpuesto TipoImpuesto { get; set; }
    }

    public enum TipoArticulo 
    { 
        Servicio,
        Producto    
    }
}
