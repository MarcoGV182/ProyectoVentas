using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TipoProductoDTO
    {
        public short TipoProductonro { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }

        public override bool Equals(object o)
        {
            if (o is TipoProductoDTO other)
            {
                return TipoProductonro == other.TipoProductonro;
            }
            return false;
        }
        public override int GetHashCode() => TipoProductonro.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
