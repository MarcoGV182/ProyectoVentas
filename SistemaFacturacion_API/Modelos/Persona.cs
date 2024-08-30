﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion_API.Modelos
{
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
        public DateTime Fecharegistro { get; set; }

        
        public short? IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario UsuarioRegistro { get; set; }

        public DateTime? Ultfechaactualizacion { get; set; }

        public short? IdUsuarioMod { get; set; }
        [ForeignKey(nameof(IdUsuarioMod))]
        public Usuario UsuarioModificacion { get; set; }

        public short? IdTipoDocIdentidad { get; set; }
        [ForeignKey(nameof(IdTipoDocIdentidad))]
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }

        public short? IdCiudad { get; set; }
        [ForeignKey(nameof(IdCiudad))]
        public Ciudad Ciudad { get; set; }



    }
}
