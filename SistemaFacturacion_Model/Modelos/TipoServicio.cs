﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos
{   
    public class TipoServicio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TipoServicioId { get; set; }

        public string Descripcion { get; set; }
    }
}
