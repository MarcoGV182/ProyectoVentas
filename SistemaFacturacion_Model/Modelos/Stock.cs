using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("stock")]
    public class Stock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }   
        public int Cantidad { get; set; }       
        public int ProductoId { get; set; }
        public int UbicacionId { get; set; }
        public DateTime? FechaActualizacion { get; set; } = DateTime.Now;



        [ForeignKey(nameof(ProductoId))]
        public virtual Producto Producto { get; set; }
       
        [ForeignKey(nameof(UbicacionId))]
        public virtual Ubicacion Ubicacion { get; set; }

        public virtual ICollection<MovimientoStock> Movimientos { get; set; }

    }
}
