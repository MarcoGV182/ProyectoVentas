using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class TablaMenorCreateDTO
    {   
        [Required]
        public string Descripcion { get; set; }
    }
}
