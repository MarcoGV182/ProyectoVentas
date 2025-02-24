using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ClienteCreateDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nrodocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Observacion { get; set; }
        public short? TipoDocumentoIdentidadId { get; set; }
        public short? CiudadId { get; set; }
    }
}
