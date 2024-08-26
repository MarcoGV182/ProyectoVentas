namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class UnidadMedidaDTO
    {
        public short Unidadmedidanro { get; set; }

        public string Descripcion { get; set; }

        public override bool Equals(object o)
        {
            if (o is UnidadMedidaDTO other)
            {
                return Unidadmedidanro == other.Unidadmedidanro;
            }
            return false;
        }
        public override int GetHashCode() => Unidadmedidanro.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
