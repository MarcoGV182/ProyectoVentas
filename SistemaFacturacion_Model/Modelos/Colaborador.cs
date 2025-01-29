using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("colaborador")]
    public class Colaborador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaId { get; set; }
        public DateTime Fechaingreso { get; set; }
        public DateTime Fechaegreso { get; set; }
        public string Estado { get; set; }       
        public decimal Salario { get; set; }


        public virtual Persona Persona { get; set; }        
    }
}
