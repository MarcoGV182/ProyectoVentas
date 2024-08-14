using SistemaFacturacion_WebAssembly.Models;
using SistemaWeb_Aplicacion.Models;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responseModel { get; set; }
        Task<APIResponse> SendAsync<T>(APIRequest apiRequest); 
    }
}
