using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("colaborador")]
    public class Colaborador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColaboradorId { get; set; }
        public DateOnly Fechaingreso { get; set; }
        public DateOnly? Fechaegreso { get; set; }
        public string Estado { get; set; }       
        public decimal Salario { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
