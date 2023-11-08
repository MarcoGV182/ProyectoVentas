using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacionWeb.Modelos
{
    public class NumeroVilla
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int IdVilla { get; set; }

        [ForeignKey(nameof(IdVilla))]
        public Villa Villa { get; set; }
        public string DetalleEspecial { get; set; }
    }
}
