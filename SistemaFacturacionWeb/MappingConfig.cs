using AutoMapper;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Modelos.DTO;

namespace SistemaFacturacionWeb
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            CreateMap<Villa, VillaCreateDTO>();
            CreateMap<VillaCreateDTO, Villa>();

            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();

            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Producto, ProductoCreateDTO>().ReverseMap();
            CreateMap<Producto, ProductoUpdateDTO>()
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ReverseMap();
        } 
    }
}
