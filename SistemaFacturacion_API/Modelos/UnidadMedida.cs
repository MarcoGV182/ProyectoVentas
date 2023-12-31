﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos
{
    public class UnidadMedida
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Unidadmedidanro { get; set; }

        public string? Descripcion { get; set; }

        public ICollection<Producto>? Productos { get; set; }
    }
}
