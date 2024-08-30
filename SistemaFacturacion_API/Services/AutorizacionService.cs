using SistemaFacturacion_API.Modelos.Custom;
using SistemaFacturacion_API.Modelos;
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

namespace SistemaFacturacion_API.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AutorizacionService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerarToken(string idUsuario) 
        {
            try
            {
                var secretKey = _configuration.GetValue<string>("JwtSettings:secretKey");
                var keyBytes = Encoding.UTF8.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim( new Claim(ClaimTypes.NameIdentifier, idUsuario));

                var credencialesToken = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(1),
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

        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var claveEncriptada = Utilidades.EncriptarClave(autorizacion.ClavePass);
            var usuario_encontrado = _context.Usuario.FirstOrDefault(x => x.Login == autorizacion.NombreUsuario && x.Password == claveEncriptada);

            if (usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(usuario_encontrado.UsuarioId.ToString());

            string refreshTokenCreado = GenerarRefreshToken();

            //var autorizacionResponde = new AutorizacionResponse() { Token = tokenCreado, Resultado = true, Mensaje = "OK" };

            return await GuardarHistorialRefreshToken(usuario_encontrado.UsuarioId,tokenCreado,refreshTokenCreado);
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

            await _context.HistorialRefreshToken.AddAsync(historialRefresh);
            await _context.SaveChangesAsync();

            return new AutorizacionResponse { Token = token,RefreshToken= refreshToken,Resultado = true, Mensaje = "OK" };
        }

        public async Task<AutorizacionResponse> DevolverRefrestToken(RefreshTokenRequest refrestTokenRequest, short idUsuario)
        {
            var refreshTokenEncontrado = _context.HistorialRefreshToken.Where(c=> 
            c.Token == refrestTokenRequest.TokenExpirado && 
            c.RefreshToken == refrestTokenRequest.RefreshToken && 
            c.UsuarioId == idUsuario).FirstOrDefault();

            if (refreshTokenEncontrado == null)
            {
                return new AutorizacionResponse()
                {
                    Resultado = false,
                    Mensaje = "No existe Token activo"
                };
            }


            var refreshTokenCreado = GenerarRefreshToken();
            var tokenCreado = GenerarToken(idUsuario.ToString());

            return await GuardarHistorialRefreshToken(idUsuario, tokenCreado, refreshTokenCreado);


        }
    }
}
