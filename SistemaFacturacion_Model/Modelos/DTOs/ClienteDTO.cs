using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ClienteDTO
    {      
        public int PersonaId { get; set; }       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nrodocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Observacion { get; set; }  
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }       
        public Ciudad Ciudad { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
