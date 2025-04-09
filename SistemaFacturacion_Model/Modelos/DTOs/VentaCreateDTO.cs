﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class VentaCreateDTO
    {
        public int Id { get; set; } 
        public string NroFactura { get; set; }
        public int Establecimiento { get; set; }
        public int PuntoExpedicion { get; set; }
        public int Numero { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; } 
        public int UbicacionId { get; set; }
        public int? ColaboradorId { get; set; }        
        public string Observacion { get; set; }
        public short TimbradoId { get; set; } 
        public string EsAutoimprenta { get; set; }
        public string Estado { get; set; } = "E";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string UsuarioIdRegistro { get; set; }
        public short? EmpresaId { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIVA { get; set; }
        public int SucursalId { get; set; }
        public List<DetalleVentaCreateDTO> DetalleVenta { get; set; }
    }
}
