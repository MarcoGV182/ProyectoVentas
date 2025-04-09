using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class TimbradoService:BaseService,ITimbradoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public TimbradoService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<TimbradoDTO>> Obtener(int id)
        {
            var result = await SendAsync<TimbradoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Timbrado/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<List<TimbradoDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<TimbradoDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Timbrado"
            });

          

            return result;
        }


        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Timbrado/{id}"
            });

         

            return result;
        }

        public async Task<APIResponse<TimbradoDTO>> Crear(TimbradoCreateDTO dto)
        {
            var result = await SendAsync<TimbradoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Timbrado"
            });

            

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id,TimbradoCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Timbrado/{id}"
            });


            return result;
        }

    }
}
