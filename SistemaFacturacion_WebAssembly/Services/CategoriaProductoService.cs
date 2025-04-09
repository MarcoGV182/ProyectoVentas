using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class CategoriaService:BaseService,ICategoriaService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public CategoriaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<CategoriaProductoDTO>> Obtener(int id)
        {
            var result = await SendAsync<CategoriaProductoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Categoria/{id}"
            });

            return result;
        }

        public async Task<APIResponse<List<CategoriaProductoDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<CategoriaProductoDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Categoria"
            });


            return result;
        }


        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Categoria/{id}"
            });
                        

            return result;
        }

        public async Task<APIResponse<CategoriaProductoDTO>> Crear(CategoriaProductoCreateDTO dto)
        {
            var result = await SendAsync<CategoriaProductoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Categoria"
            });

         

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, CategoriaProductoCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Categoria/{id}"
            });

          

            return result;
        }

    }
}
