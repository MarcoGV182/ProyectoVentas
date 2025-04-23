using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class SucursalDTO
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Empresa Empresa { get; set; }

        public override bool Equals(object o)
        {
            var other = o as SucursalDTO;
            return other?.SucursalId == SucursalId;
        }
        public override int GetHashCode() => SucursalId.GetHashCode();
        public override string ToString()
        {
            return $"{Nombre} ({SucursalId})";
        }
    }
}
