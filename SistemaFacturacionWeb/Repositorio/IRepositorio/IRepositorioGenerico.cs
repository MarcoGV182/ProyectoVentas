using System.Linq.Expressions;

namespace SistemaFacturacionWeb.Repositorio.IRepositorio
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task Crear(T entidad);
        Task<List<T>> ObtenerTodos(Expression<Func<T,bool>>? filtro = null, params string[] includes);

        Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true, params string[] includes);

        Task Eliminar(T entidad);

        Task Grabar();
    }
}
