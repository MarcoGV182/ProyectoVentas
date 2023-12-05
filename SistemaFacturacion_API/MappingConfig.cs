using AutoMapper;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Modelos.DTO;

namespace SistemaFacturacion_API
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Producto, ProductoCreateDTO>().ReverseMap();
            CreateMap<Producto, ProductoUpdateDTO>()
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ReverseMap();
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Marca, MarcaCreateDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDTO>().ReverseMap();
            CreateMap<TipoImpuesto, TipoImpuestoDTO>().ReverseMap();
        } 
    }
}
