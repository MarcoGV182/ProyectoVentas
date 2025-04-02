using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;


namespace SistemaFacturacion_WebAssembly.Services
{
    public class VentaService : BaseService, IVentaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VentaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<APIResponse<T>> ObtenerVentas<T>()
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Venta"

            });

            

            return result;
        }


        public async Task<APIResponse<T>> RegistrarVenta<T>(VentaCreateDTO venta)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = venta,
                URL = $"api/Venta"
            });

           

            return result;
        }
    }
}
