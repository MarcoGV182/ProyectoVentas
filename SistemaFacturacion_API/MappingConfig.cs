using AutoMapper;
using Npgsql.PostgresTypes;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Model.Modelos;

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

            //Servicio
            CreateMap<Servicio, ServicioDTO>().ForMember(dest => dest.ServicioId, opt => opt.MapFrom(src => src.ArticuloId)).ReverseMap();
            CreateMap<Servicio, ServicioCreateDTO>().ReverseMap();


            //Marca
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Marca, MarcaCreateDTO>().ReverseMap();
            //Usuario
            //CreateMap<Usuario, UsuarioRegistroDTO>().ReverseMap();
            //Colaborador
            CreateMap<Colaborador, ColaboradorDTO>().ReverseMap();
            //Tipo Impuesto
            CreateMap<TipoImpuesto, TipoImpuestoDTO>().ReverseMap();
            CreateMap<TipoImpuesto, TipoImpuestoCreateDTO>().ReverseMap();
            //Tipo Producto
            CreateMap<CategoriaProducto, CategoriaProductoCreateDTO>().ReverseMap();
            CreateMap<CategoriaProducto, CategoriaProductoDTO>().ReverseMap();
            //Tipo Servicio
            CreateMap<TipoServicio, TipoServicioDTO>().ReverseMap();
            CreateMap<TipoServicio, TablaMenorCreateDTO>().ReverseMap();    
            //Presentacion
            CreateMap<Presentacion, PresentacionCreateDTO>().ReverseMap();
            CreateMap<Presentacion, PresentacionDTO>().ReverseMap();
            //Unidad Medida
            CreateMap<UnidadMedida, UnidadMedidaDTO>().ReverseMap();
            CreateMap<UnidadMedida, UnidadMedidaCreateDTO>().ReverseMap();
            //Timbrado
            CreateMap<TimbradoDTO, Timbrado>()
               .ForMember(dest => dest.FechaInicioVigencia, opt => opt.MapFrom(src => src.FechaInicioVigencia.Date))
               .ForMember(dest => dest.FechaFinVigencia, opt => opt.MapFrom(src => src.FechaFinVigencia.Date))
               .ReverseMap();

            // Mapeo entre TimbradoCreateDTO y Timbrado
            CreateMap<TimbradoCreateDTO, Timbrado>()
                .ForMember(dest => dest.FechaInicioVigencia, opt => opt.MapFrom(src => src.FechaInicioVigencia.Date))
                .ForMember(dest => dest.TipoTimbrado, opt => opt.MapFrom(src => src.TipoTimbrado.ToString()))
                .ForMember(dest => dest.FechaFinVigencia, opt => opt.MapFrom(src => src.FechaFinVigencia.Date));

            //Ciudad
            CreateMap<Ciudad, CiudadDTO>().ReverseMap();
            CreateMap<Ciudad, CiudadCreateDTO>().ReverseMap();

            CreateMap<TipoDocumentoIdentidad, TablaMenorCreateDTO>().ReverseMap();

        }
    }
}
