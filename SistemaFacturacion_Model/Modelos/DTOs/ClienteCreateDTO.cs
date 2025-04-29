using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ClienteCreateDTO
    {
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage ="El nro de documento es requerido")]
        public string Nrodocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage ="El formato de la dirección de correo no es válido")]
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Observacion { get; set; }        
        public short? TipoDocIdentidadId { get; set; }
        public short? CiudadId { get; set; }
    }


   
}
