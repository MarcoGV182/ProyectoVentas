using SistemaFacturacion_Utilidad;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IBaseService
    {
        Task<APIResponse<T>> SendAsync<T>(APIRequest apiRequest) where T : class, new();
    }
}
