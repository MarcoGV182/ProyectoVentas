using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SistemaFacturacion_Model.Modelos
{
    public class Sucursal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public short EmpresaId { get; set; }


        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();
    }
}
