using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IClienteRepositorio: IRepositorioGenerico<Persona>
    {
        Task<Persona> Actualizar(Persona entidad);
    }
}
