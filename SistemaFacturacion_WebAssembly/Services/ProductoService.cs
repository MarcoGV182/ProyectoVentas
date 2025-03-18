﻿using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;
using DocumentFormat.OpenXml.Office2010.Excel;
using SistemaFacturacion_Model.Modelos.DTOs;
using Newtonsoft.Json;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ProductoService : BaseService, IProductoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _productoURL;
        public ProductoService(IHttpClientFactory httpClientFactory,IConfiguration configuracion):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productoURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
        }

        public async Task<APIResponse> Crear<T>(ProductoCreateDTO dto)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
        public async Task<APIResponse> Actualizar<T>(int id,ProductoUpdateDTO dto)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto/{id}"
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
                URL = $"{_productoURL}/api/Producto/{id}"
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
                URL = $"{_productoURL}/api/Producto"
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
                URL = $"{_productoURL}/api/Producto/{id}"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
    }
}
