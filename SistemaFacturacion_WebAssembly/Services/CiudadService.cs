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
    public class CiudadService : BaseService, ICiudadService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CiudadService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<T>> Crear<T>(CiudadCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Ciudad"
            });
                        

            return result;
        }
        public async Task<APIResponse<T>> Actualizar<T>(int id, CiudadDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Ciudad/{id}"
            });

           
            return result;
        }

        public async Task<APIResponse<T>> Obtener<T>(int id)
        {   
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Ciudad/{id}"

            });

            return result;
        }

        public async Task<APIResponse<T>> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Ciudad"
            });
       

            return result;
        }

        public async Task<APIResponse<T>> Eliminar<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Ciudad/{id}"
            });

     
            return result;
        }
    }
}
