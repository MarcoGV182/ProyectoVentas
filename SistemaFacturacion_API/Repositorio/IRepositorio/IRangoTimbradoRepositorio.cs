using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IRangoTimbradoRepositorio:IRepositorioGenerico<Rango_Timbrados>
    {
        Task<Rango_Timbrados> Actualizar(Rango_Timbrados entidad);
        Task ActualizarNroActual(int idRango, int nuevoNroActual);
    }
}
