using AutoMapper;
using SistemaFacturacion_Web.Models.DTO;

namespace SistemaFacturacion_Web
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<MarcaDTO, MarcaCreateDTO>().ReverseMap();
            CreateMap<ProductoDTO, ProductoCreateDTO>().ReverseMap();
            CreateMap<ProductoDTO, ProductoUpdateDTO>().ReverseMap();
        }
    }
}
