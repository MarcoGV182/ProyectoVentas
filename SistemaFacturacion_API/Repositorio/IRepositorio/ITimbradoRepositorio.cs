using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface ITimbradoRepositorio:IRepositorioGenerico<Timbrado>
    {
        Task<Timbrado> ActualizarAsync(Timbrado entidad);

        bool ExisteTimbradoAsync(short id);
    }
}
