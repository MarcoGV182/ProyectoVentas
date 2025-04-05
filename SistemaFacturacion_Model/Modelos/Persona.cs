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
        public string UsuarioRegistro { get; set; }       
        public DateTime? Ultfechaactualizacion { get; set; }
        public string UsuarioIdMod { get; set; }
        public short? TipoDocIdentidadId { get; set; }
        public short? CiudadId { get; set; }
        public int? SucursalId { get; set; }



        [ForeignKey(nameof(TipoDocIdentidadId))]
        public virtual TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }
        [ForeignKey(nameof(CiudadId))]
        public virtual Ciudad Ciudad { get; set; }
        // Relación con Colaborador
        public virtual Colaborador Colaborador { get; set; }     
        public virtual Sucursal Sucursal { get; set; }

    }
}
