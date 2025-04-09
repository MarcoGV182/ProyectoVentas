﻿using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class PresentacionService:BaseService,IPresentacionService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public PresentacionService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<PresentacionDTO>> Obtener(int id)
        {
            var result = await SendAsync<PresentacionDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Presentacion/{id}"
            });

         
            return result;
        }

        public async Task<APIResponse<List<PresentacionDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<PresentacionDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Presentacion"
            });

           

            return result;
        }


        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Presentacion/{id}"
            });

          
            return result;
        }

        public async Task<APIResponse<PresentacionDTO>> Crear(PresentacionCreateDTO dto)
        {
            var result = await SendAsync<PresentacionDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Presentacion"
            });

          

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, PresentacionCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Presentacion/{id}"
            });

          

            return result;
        }

    }
}
