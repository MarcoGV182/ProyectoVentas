using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TipoImpuestoDTO
    {
        public int TipoimpuestoNro { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; } = 0;

        public double Baseimponible { get; set; } = 0;


        public override bool Equals(object o)
        {
            if (o is TipoImpuestoDTO other)
            {
                return TipoimpuestoNro == other.TipoimpuestoNro;
            }
            return false;
        }
        public override int GetHashCode() => TipoimpuestoNro.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
