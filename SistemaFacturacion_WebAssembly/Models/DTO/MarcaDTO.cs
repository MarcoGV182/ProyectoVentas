using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class MarcaDTO
    {
        public int Marcanro { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerida")]
        public string Descripcion { get; set; } = null!;

        public override bool Equals(object o)
        {
            if (o is MarcaDTO other)
            {
                return Marcanro == other.Marcanro;
            }
            return false;
        }
        public override int GetHashCode() => Marcanro.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
