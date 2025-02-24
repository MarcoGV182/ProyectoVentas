using Blazored.LocalStorage;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;
using System;
using System.Net.Http;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MarcaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse> Crear<T>(MarcaCreateDTO dto)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Marca"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
        public async Task<APIResponse> Actualizar<T>(int id, MarcaCreateDTO dto)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Marca/{id}"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<APIResponse> Obtener<T>(int id)
        {   
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Marca/{id}"

            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<APIResponse> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Marca"
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
                URL = $"api/Marca/{id}"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
    }
}
