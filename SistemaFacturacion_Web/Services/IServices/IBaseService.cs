using SistemaFacturacion_Web.Models;
using SistemaWeb_Aplicacion.Models;

namespace SistemaFacturacion_Web.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest); 
    }
}
