using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ColaboradorDTO
    {
        public int ColaboradorId { get; set; }
        public DateOnly Fechaingreso { get; set; }
        public DateOnly? Fechaegreso { get; set; }
        public string Estado { get; set; }    
        public double Salario { get; set; }
        public Persona Persona { get; set; }
    }
}
