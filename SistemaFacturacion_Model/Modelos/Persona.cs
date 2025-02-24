using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SistemaFacturacion_Model.Modelos
{
    [Table("persona")]
    public class Persona
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nrodocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Observacion { get; set; }
        [Required]
        public DateTime Fecharegistro { get; set; } = DateTime.Now;
        public short? IdUsuario { get; set; }       
        public DateTime? Ultfechaactualizacion { get; set; }
        public short? IdUsuarioMod { get; set; }
        public short? IdTipoDocIdentidad { get; set; }
        [ForeignKey(nameof(IdTipoDocIdentidad))]
        public virtual TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }

        public short? IdCiudad { get; set; }
        [ForeignKey(nameof(IdCiudad))]
        public Ciudad Ciudad { get; set; }
        // Relación con Colaborador
        public virtual Colaborador Colaborador { get; set; }



    }
}
