﻿using Blazored.LocalStorage;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UsuarioService: BaseService, IUsuarioService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public UsuarioService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse> Crear<T>(UsuarioRegistroDTO dto)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Usuario"
            };

            var result = await SendAsync<APIResponse>(apiRequest);

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<APIResponse> Actualizar<T>(int id,UsuarioRegistroDTO dto)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Usuario/{id}"
            };

            var result = await SendAsync<APIResponse>(apiRequest);

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<AutorizacionResponse> IniciarSesion(LoginDTO login)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = login,
                URL = $"api/Usuario/IniciarSesion"
            };

            var result = await SendAsync<AutorizacionResponse>(apiRequest);

            return result;
        }

        public async Task<AutorizacionResponse> RefrescarToken(TokenRequest tokenRequest)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = tokenRequest,
                URL = $"api/Usuario/RefreshToken"
            };

            var result = await SendAsync<AutorizacionResponse>(apiRequest);

            return result;
        }

        public async Task<APIResponse> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Usuario"
            });


            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<APIResponse> Eliminar<T>(int id)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Usuario/{id}"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
    }
}
