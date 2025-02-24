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
using AutoMapper.Configuration.Annotations;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaFacturacion_Utilidad;
using System.Transactions;
using SistemaFacturacion_API.Repositorio;

namespace SistemaFacturacion_API.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenRepositorio _refreshTokenRepositorio;
        private readonly JWTConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AutorizacionService(ApplicationDbContext context, IConfiguration configuration, IOptions<JWTConfig> jwtConfig, IRefreshTokenRepositorio refreshTokenRepositorio, TokenValidationParameters tokenValidationParameters)
        {
            _context = context;
            _configuration = configuration;
            _jwtConfig = jwtConfig.Value;
            _refreshTokenRepositorio = refreshTokenRepositorio;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AutorizacionResponse> GenerarTokenAsync(IdentityUser user) 
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
                    Expires = DateTime.UtcNow.Add(_jwtConfig.ExpireTime),
                    SigningCredentials = credencialesToken
                };


                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                var tokenCreado = tokenHandler.WriteToken(tokenConfig);
                //Crear refresh Token
                var refreshToken = new RefreshToken
                {
                    JwtId = tokenConfig.Id,
                    UserId = user.Id,
                    Token = Shared.GenerateRandomString(23),
                    FechaGrab = DateTime.UtcNow,
                    FechaExpiracion = DateTime.UtcNow.AddDays(30),
                    IsRevoked = false,
                    IsUsed = false
                };

                await _refreshTokenRepositorio.Crear(refreshToken);

                return new AutorizacionResponse
                {
                    Token = tokenCreado,
                    RefreshToken = refreshToken.Token,
                    Resultado = true
                };
            }
            catch (Exception ex)
            {
                return new AutorizacionResponse
                {                   
                    Resultado = false,
                    Mensaje = new List<string> { ex.Message }
                };
            }       
        }


        public async Task<string> VerificarTokenAsync(TokenRequest tokenrequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                _tokenValidationParameters.ValidateLifetime = false;

                var tokenVerified = jwtTokenHandler.ValidateToken(tokenrequest.Token, _tokenValidationParameters, out var validatedToken);
                if (validatedToken is JwtSecurityToken jwtSecurityToken) 
                { 
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,StringComparison.InvariantCultureIgnoreCase);

                    if (!result || tokenVerified == null) 
                        throw new Exception("Token Inválido");
                }


                var utcFechaExpiracion = long.Parse(tokenVerified.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp).Value);
                var fechaExpiracion = DateTimeOffset.FromUnixTimeSeconds(utcFechaExpiracion).UtcDateTime;
                if (fechaExpiracion < DateTime.UtcNow)
                    throw new Exception("Token Expirado");


                var storedToken = await _refreshTokenRepositorio.Obtener(c => c.Token == tokenrequest.RefreshToken);
                if (storedToken == null) 
                    throw new Exception("Token Inválido");

                if (storedToken.IsRevoked || storedToken.IsUsed)
                    throw new Exception("Token Inválido");

                var jti = tokenVerified.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value;
                if (jti != storedToken.JwtId)
                    throw new Exception("Token Inválido");


                if (storedToken.FechaExpiracion < DateTime.UtcNow) 
                    throw new Exception("Token Expirado");


                storedToken.IsUsed = true;
                await _refreshTokenRepositorio.Actualizar(storedToken);


                return storedToken.UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
