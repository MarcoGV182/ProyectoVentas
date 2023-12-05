using SistemaFacturacion_Utilidad;
using SistemaFacturacion_Web.Models.DTO;
using SistemaFacturacion_Web.Models;
using SistemaFacturacion_Web.Services.IServices;

namespace SistemaFacturacion_Web.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _marcaURL;
        public MarcaService(IHttpClientFactory httpClientFactory,IConfiguration configuracion):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _marcaURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
        }

        public Task<T> Crear<T>(MarcaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_marcaURL}/api/Marca"
            });
        }
        public Task<T> Actualizar<T>(MarcaDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_marcaURL}/api/Marca/{dto.Marcanro}"
            });
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_marcaURL}/api/Marca/{id}"
            });
        }

        public Task<T> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_marcaURL}/api/Marca"
            });
        }

        public Task<T> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"{_marcaURL}/api/Marca/{id}"
            });
        }
    }
}
