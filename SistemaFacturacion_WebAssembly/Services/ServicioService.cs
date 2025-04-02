using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;
using DocumentFormat.OpenXml.Office2010.Excel;
using SistemaFacturacion_Model.Modelos.DTOs;
using Newtonsoft.Json;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ServicioService : BaseService, IServicioService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _productoURL;
        public ServicioService(IHttpClientFactory httpClientFactory,IConfiguration configuracion):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productoURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
        }

        public async Task<APIResponse<T>> Crear<T>(ServicioCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_productoURL}/api/Servicio"
            });


            return result;
        }
        public async Task<APIResponse<T>> Actualizar<T>(int id, ServicioCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_productoURL}/api/Servicio/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<T>> Obtener<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Servicio/{id}"
            });

            return result;
        }

        public async Task<APIResponse<T>> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Servicio"
            });

           

            return result;
        }

        public async Task<APIResponse<T>> Eliminar<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"{_productoURL}/api/Servicio/{id}"
            });

         

            return result;
        }
    }
}
