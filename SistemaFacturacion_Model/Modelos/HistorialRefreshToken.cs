using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_Model.Modelos
{
    public class HistorialRefreshToken
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistorialTokenId { get; set; }
        public short UsuarioId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? EsActivo { get ; set ; }

    }
}
