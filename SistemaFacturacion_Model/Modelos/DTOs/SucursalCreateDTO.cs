using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class SucursalCreateDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public short EmpresaId { get; set; }
    }
}
