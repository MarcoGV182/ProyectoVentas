using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_Model.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Datos;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using SistemaFacturacion_API.Recursos;
using Microsoft.Extensions.Options;
using SistemaFacturacion_API.Configuracion;
using Microsoft.AspNetCore.Identity;

namespace SistemaFacturacion_API.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly JWTConfig _jwtConfig;

        public AutorizacionService(ApplicationDbContext context, IConfiguration configuration,IOptions<JWTConfig> jwtConfig)
        {
            _context = context;
            _configuration = configuration;
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerarToken(IdentityUser user) 
        {
            try
            {
                //var secretKey = _configuration.GetValue<string>("JwtSettings:secretKey");
                var keyBytes = Encoding.UTF8.GetBytes(_jwtConfig.SecretKey);

                var credencialesToken = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new ClaimsIdentity(new[]
                    {
                        new Claim("Id", user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                        new Claim(JwtRegisteredClaimNames.Email,user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                    })),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = credencialesToken
                };


                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return tokenCreado;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }       
        }

        private string GenerarRefreshToken() 
        {
            var byteArray = new byte[64];
            var refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }

            return refreshToken;
        }

        private async Task<AutorizacionResponse> GuardarHistorialRefreshToken(short idUsuario,string token,string refreshToken) 
        {
            var historialRefresh = new HistorialRefreshToken()
            {
                UsuarioId = idUsuario,
                Token = token,
                RefreshToken = refreshToken,
                FechaCreacion = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddMinutes(2)
            };

            await _context.HistorialesRefreshTokens.AddAsync(historialRefresh);
            await _context.SaveChangesAsync();

            return new AutorizacionResponse { Token = token,RefreshToken= refreshToken,Resultado = true, Mensaje = new List<string>() { "OK" } };
        }
    }
}
