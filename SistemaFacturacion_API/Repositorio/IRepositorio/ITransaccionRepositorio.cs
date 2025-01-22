using SistemaFacturacion_Model.Modelos;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITransaccionRepositorio<TCabecera,TDetalle> 
        where TCabecera : class
        where TDetalle : class
    {
        Task Registrar(TCabecera cabecera, IEnumerable<TDetalle> detalles);
        Task<List<TCabecera>> ObtenerTodos(Expression<Func<TCabecera, bool>>? filtro = null, string incluirPropiedades = null);

        Task<TCabecera> Obtener(Expression<Func<TCabecera, bool>>? filtro = null, bool tracked = true, string incluirPropiedades = null);

        Task Anular(TCabecera entidad);

        Task Grabar();
    }
}
