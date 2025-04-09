using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class RangoTimbradoService:BaseService,IRangoTimbradoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public RangoTimbradoService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<RangoTimbradoDTO>> Obtener(int id)
        {
            var result = await SendAsync<RangoTimbradoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/RangoTimbrado/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<List<RangoTimbradoDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<RangoTimbradoDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/RangoTimbrado"
            });

          

            return result;
        }


        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/RangoTimbrado/{id}"
            });

         

            return result;
        }

        public async Task<APIResponse<RangoTimbradoDTO>> Crear(RangoTimbradoCreateDTO dto)
        {
            var result = await SendAsync<RangoTimbradoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/RangoTimbrado"
            });

            

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id,RangoTimbradoCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/RangoTimbrado/{id}"
            });


            return result;
        }

    }
}
