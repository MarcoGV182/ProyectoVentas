﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public string NroFactura { get; set; }
        public short Establecimiento { get; set; }
        public short PuntoExpedicion { get; set; }
        public int Numero { get; set; }   
        public Persona Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public Colaborador Vendedor { get; set; }
        public Timbrado Timbrado { get; set; }
        public Empresa Empresa { get; set; }
        public string EsAutoimprenta { get; set; }       
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public short UsuarioIdRegistro { get; set; }        
        public string Observacion { get; set; }
        public IEnumerable<DetalleVenta> DetalleVenta { get; set; }
    }
}
