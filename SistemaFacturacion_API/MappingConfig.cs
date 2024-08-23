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
            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.Marcanro, opt => opt.MapFrom(src => src.Marca.Marcanro))
                .ForMember(dest => dest.MarcaDescripcion, opt => opt.MapFrom(src => src.Marca.Descripcion))
                .ForMember(dest => dest.TipoimpuestoNro, opt => opt.MapFrom(src => src.TipoImpuesto.TipoimpuestoNro))
                .ForMember(dest => dest.TipoImpuestoDescripcion, opt => opt.MapFrom(src => src.TipoImpuesto.Descripcion))
                .ForMember(dest => dest.Baseimponible, opt => opt.MapFrom(src => src.TipoImpuesto.Baseimponible))
                .ForMember(dest => dest.Porcentajeiva, opt => opt.MapFrom(src => src.TipoImpuesto.Porcentajeiva))
                .ForMember(dest => dest.Idpresentacion, opt => opt.MapFrom(src => src.Presentacion.Idpresentacion))
                .ForMember(dest => dest.PresentacionDescripcion, opt => opt.MapFrom(src => src.Presentacion.Descripcion))
                .ForMember(dest => dest.TipoProductonro, opt => opt.MapFrom(src => src.TipoProducto.TipoProductonro))
                .ForMember(dest => dest.TipoProductoDescripcion, opt => opt.MapFrom(src => src.TipoProducto.Descripcion))
                .ForMember(dest => dest.Unidadmedidanro, opt => opt.MapFrom(src => src.UnidadMedida.Unidadmedidanro))
                .ForMember(dest => dest.UMDescripcion, opt => opt.MapFrom(src => src.UnidadMedida.Descripcion));



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
            //Presentacion
            CreateMap<Presentacion, PresentacionCreateDTO>().ReverseMap();
            CreateMap<Presentacion, PresentacionDTO>().ReverseMap();
        } 
    }
}
