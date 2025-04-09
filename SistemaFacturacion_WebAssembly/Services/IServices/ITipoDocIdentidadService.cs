using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITipoDocIdentidadService
    {
        Task<APIResponse<List<TablaMenorDTO>>> ObtenerTodos();
        Task<APIResponse<TablaMenorDTO>> Obtener(int id);
        Task<APIResponse<TablaMenorDTO>> Crear(TablaMenorCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, TablaMenorCreateDTO dto);
    }
}
