﻿namespace SistemaFacturacion_API.Modelos.Custom
{
    public class RefreshTokenRequest
    {
        public string TokenExpirado { get; set; }
        public string RefreshToken { get; set; }
    }
}
