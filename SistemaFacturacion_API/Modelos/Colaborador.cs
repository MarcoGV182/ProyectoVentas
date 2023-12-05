using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
    public class Colaborador: Persona
    {
        public DateOnly Fechaingreso { get; set; }
        public DateOnly? Fechaegreso { get; set; }
        public string? Estado { get; set; }
        public int? UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Usuario { get; set; }
        public double? Salario { get; set; }
    }
}
