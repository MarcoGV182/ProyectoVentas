using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ISucursalRepositorio:IRepositorioGenerico<Sucursal>
    {
        Task<Sucursal> Actualizar(Sucursal entidad);
    }
}
