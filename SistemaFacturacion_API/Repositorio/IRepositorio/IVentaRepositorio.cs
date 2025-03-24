using Microsoft.EntityFrameworkCore.Storage;
using SistemaFacturacion_Model.Modelos;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IVentaRepositorio: IRepositorioGenerico<Venta>
    {
        Task CreateVentaAsync(Venta venta);
    }
}
