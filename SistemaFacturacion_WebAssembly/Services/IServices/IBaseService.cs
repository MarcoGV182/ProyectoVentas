using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaWeb_Aplicacion.Models;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IBaseService
    {
        Task<T> SendAsync<T>(APIRequest apiRequest) where T : class, new();
    }
}
