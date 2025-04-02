using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class ArticuloDTO
    {
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Favor ingrese la Descripcion")]
        public string Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public string Observacion { get; set; }
        public int StockActual { get; set; }
        public string Estado { get; set; }
        public TipoArticulo TipoArticulo { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public DateTime? Fechaultactualizacion { get; set; }        
        public TipoImpuestoDTO TipoImpuesto { get; set; }
        //public ICollection<PrecioPromocional> PreciosPromocionales { get; set; }
    }
}
