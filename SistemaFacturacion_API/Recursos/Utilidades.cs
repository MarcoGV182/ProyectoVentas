using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace SistemaFacturacion_API.Recursos
{
    public class Utilidades
    {
        public static string EncriptarClave(string clave)
        {
            var passEncriptado = BCrypt.Net.BCrypt.HashPassword(clave);

            return passEncriptado;
        }
    }
}
