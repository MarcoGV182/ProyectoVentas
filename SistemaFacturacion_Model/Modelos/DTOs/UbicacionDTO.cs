using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class UbicacionDTO
    {
        public int UbicacionId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
