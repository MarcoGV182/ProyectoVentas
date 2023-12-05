using SistemaFacturacion_Web.Models.DTO;

namespace SistemaFacturacion_Web.Services.IServices
{
    public interface IMarcaService
    {
        Task<T> ObtenerTodos<T>();
        Task<T> Obtener<T>(int id);
        Task<T> Crear<T>(MarcaCreateDTO dto);
        Task<T> Actualizar<T>(MarcaDTO dto);
        Task<T> Eliminar<T>(int id);
    }
}
