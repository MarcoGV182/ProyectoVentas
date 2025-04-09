using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IClienteService
    {
        Task<APIResponse<List<ClienteDTO>>> ObtenerTodos();
        Task<APIResponse<ClienteDTO>> Obtener(int id);
        Task<APIResponse<ClienteDTO>> Crear(ClienteCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, ClienteCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
    }
}
