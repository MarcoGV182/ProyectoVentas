namespace SistemaFacturacion_API.Configuracion
{
    public class JWTConfig
    {
        public string SecretKey { get; set; }
        public TimeSpan ExpireTime { get; set; }
    }
}
