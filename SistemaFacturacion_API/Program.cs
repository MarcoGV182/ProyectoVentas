using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API;
using SistemaFacturacion_API.Configuracion;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_API.Datos;
using Microsoft.Extensions.Options;
using SistemaFacturacion_Model.Modelos;
using System.Security.Claims;

string myCors = "AllowBlazor";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region SWAGGER
//Configuracion de SWAGGER
builder.Services.AddSwaggerGen(c =>
{
    //Titulo
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaFacturacion_API", Version = "v1" });

    //Boton Autorize (Swagger)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer Scheme",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
            Reference = new OpenApiReference{
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        }, new string[]{ }
        }
    });
});
#endregion


//Evitar Referencias cíclicas
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy(myCors, policy =>
    {
        policy.WithOrigins("https://localhost:7147") // Solo el dominio permitido
              .AllowAnyHeader()                     // Permitir todos los encabezados
              .AllowAnyMethod()                     // Permitir todos los métodos HTTP
              .AllowCredentials();                  // Permitir cookies o credenciales
    });
});

builder.Services.InyectarDependencia(builder.Configuration);

#region Configuracion de JWT
builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JwtSettings"));

var secretkey = builder.Configuration.GetSection("JwtSettings:SecretKey").Value;//builder.Configuration.GetSection("JwtSetting").GetSection("secretKey").ToString();
var keyBytes = Encoding.ASCII.GetBytes(secretkey);
var tokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
    ValidateIssuer = false,
    ValidateAudience = false,
    RequireExpirationTime = false,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero,
    NameClaimType = ClaimTypes.Name,
    RoleClaimType = ClaimTypes.Role
};
builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = tokenValidationParameters;
});
#endregion




AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myCors);

app.UseAuthentication();    

app.UseAuthorization();

app.MapControllers();

app.Run();
