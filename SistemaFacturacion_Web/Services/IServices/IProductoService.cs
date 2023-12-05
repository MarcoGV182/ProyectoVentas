using SistemaFacturacion_Web.Models.DTO;

namespace SistemaFacturacion_Web.Services.IServices
{
    public interface IProductoService
    {
        Task<T> ObtenerTodos<T>();
        Task<T> Obtener<T>(int id);
        Task<T> Crear<T>(ProductoCreateDTO dto);
        Task<T> Actualizar<T>(ProductoUpdateDTO dto);
        Task<T> Eliminar<T>(int id);
    }
}
