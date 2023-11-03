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
        }
    }
}
