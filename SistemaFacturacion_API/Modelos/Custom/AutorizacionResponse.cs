﻿namespace SistemaFacturacion_API.Modelos.Custom
{
    public class AutorizacionResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
    }
}
