using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Utilidad
{
    public class Shared
    {
        public decimal CalcularImpuesto(decimal ImporteTotal, decimal porcentaje,decimal baseImponible,int cantidadDecimales,string Retorno) 
        {
            #region Variables
            decimal resultado = 0;
            decimal importeIVA = 0;
            decimal importeGrav = 0;
            decimal importeExento = 0;
            decimal importeNeto = 0;
            #endregion

            if (porcentaje>0)
            {
                importeIVA = Math.Round(ImporteTotal / ((10000 / (baseImponible * porcentaje)) + 1), cantidadDecimales);
                importeNeto = ImporteTotal - importeIVA;
                importeExento = Math.Round(importeNeto * ((100 - baseImponible) / 100), cantidadDecimales);
                importeGrav = ImporteTotal - importeExento - importeIVA;
            }
            else
            {
                importeIVA = 0;
                importeNeto = ImporteTotal - importeIVA;
                importeExento = Math.Round(importeNeto * ((100 - baseImponible) / 100), cantidadDecimales);
                importeGrav = ImporteTotal - importeExento - importeIVA;
            }


            switch (Retorno.ToUpper())
            {
                case "IVA":
                    resultado = importeIVA;
                    break;
                case "GRAVADO":
                    resultado = importeGrav; 
                    break;
                case "EXENTO":
                    resultado = importeExento;
                    break;
                default:
                    break;
            }

            return resultado;
        }
            
        public static string GenerateRandomString(int size) 
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz$#-_.";

            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        
        }


        public static string GetDisplayName(Enum value)
        {
            return value.GetType()
                        .GetField(value.ToString())
                        ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                        is DisplayAttribute[] displayAttributes && displayAttributes.Length > 0
                ? displayAttributes[0].Name
                : value.ToString();
        }

        public static List<KeyValuePair<int, string>> ToListWithDisplayName<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<Enum>()
                       .Select(e => new KeyValuePair<int, string>(Convert.ToInt32(e), GetDisplayName(e)))
                       .ToList();
        }
    }
}
