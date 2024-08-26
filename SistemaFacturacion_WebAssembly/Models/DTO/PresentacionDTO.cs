using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class PresentacionDTO
    {
        public short Idpresentacion { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }

        public override bool Equals(object o)
        {
            if (o is PresentacionDTO other)
            {
                return Idpresentacion == other.Idpresentacion;
            }
            return false;
        }
        public override int GetHashCode() => Idpresentacion.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
