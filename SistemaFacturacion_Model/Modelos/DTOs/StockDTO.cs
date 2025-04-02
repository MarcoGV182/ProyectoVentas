using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class StockDTO
    {
        public int ProductoId { get; set; }
        public int UbicacionId { get; set; }
        public int Cantidad { get; set; }
    }
}
