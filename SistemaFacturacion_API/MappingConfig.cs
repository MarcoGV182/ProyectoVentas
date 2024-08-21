using AutoMapper;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Modelos.DTO;

namespace SistemaFacturacion_API
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            //Producto
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Producto, ProductoCreateDTO>().ReverseMap();
            CreateMap<Producto, ProductoUpdateDTO>()
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ReverseMap();

            //Marca
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Marca, MarcaCreateDTO>().ReverseMap();
            //Usuario
            CreateMap<Usuario, UsuarioCreateDTO>().ReverseMap();
            //Colaborador
            CreateMap<Colaborador, ColaboradorDTO>().ReverseMap();
            //Tipo Impuesto
            CreateMap<TipoImpuesto, TipoImpuestoDTO>().ReverseMap();
            CreateMap<TipoImpuesto, TipoImpuestoCreateDTO>().ReverseMap();

            //Tipo Producto
            CreateMap<TipoProducto, TipoProductoCreateDTO>().ReverseMap();
            CreateMap<TipoProducto, TipoProductoDTO>().ReverseMap();
        } 
    }
}
