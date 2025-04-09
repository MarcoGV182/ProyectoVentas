using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class SucursalService:BaseService,ISucursalService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public SucursalService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<SucursalDTO>> Obtener(int id)
        {
            var result = await SendAsync<SucursalDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Sucursal/{id}"
            });

         
            return result;
        }

        public async Task<APIResponse<List<SucursalDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<SucursalDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Sucursal"
            });

           

            return result;
        }


        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Sucursal/{id}"
            });

          
            return result;
        }

        public async Task<APIResponse<SucursalDTO>> Crear(SucursalCreateDTO dto)
        {
            var result = await SendAsync<SucursalDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Sucursal"
            });

          

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, SucursalCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Sucursal/{id}"
            });

          

            return result;
        }

    }
}
