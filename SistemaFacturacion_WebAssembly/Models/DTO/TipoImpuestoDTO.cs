﻿using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models.DTO
{
    public class TipoImpuestoDTO
    {
        public int TipoimpuestoNro { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }

        public double Porcentajeiva { get; set; } = 0;

        public double Baseimponible { get; set; } = 0;
    }
}