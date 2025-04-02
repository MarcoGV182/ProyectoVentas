using AutoMapper;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Mappers.Resolvers
{
    public class ItemIdResolver : IValueResolver<DetalleVentaCreateDTO, DetalleVenta, int>
    {
        public int Resolve(DetalleVentaCreateDTO source, DetalleVenta destination, int destMember, ResolutionContext context)
        {
            // Validación básica (puedes mejorarla)
            if (source.ItemId <= 0)
                throw new ArgumentException("ItemId no válido");

            return source.ItemId;
        }

    }
}
