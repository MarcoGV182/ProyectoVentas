using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITipoDocumentoIdentidadRepositorio:IRepositorioGenerico<TipoDocumentoIdentidad>
    {
        Task<TipoDocumentoIdentidad> Actualizar(TipoDocumentoIdentidad entidad);
    }
}
