using AutoMapper;
using Npgsql.PostgresTypes;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Mappers.Resolvers;
using SistemaFacturacion_API.Datos;

namespace SistemaFacturacion_API.Mappers
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            /*CreateMap<ArticuloDTO, Articulo>()
            .Include<ArticuloDTO, Producto>()
            .Include<ArticuloDTO, Servicio>()
            .ConvertUsing((src, dest, context) =>
            {
                return src.TipoArticulo switch
                {
                    TipoArticulo.Producto => context.Mapper.Map<Producto>(src),
                    TipoArticulo.Servicio => context.Mapper.Map<Servicio>(src),
                    _ => throw new ArgumentException("TipoArticulo desconocido", nameof(src.TipoArticulo))
                };
            });


            CreateMap<ArticuloDTO, Producto>()
                .ForMember(dest => dest.TipoArticulo, opt => opt.MapFrom(src => TipoArticulo.Producto));

            CreateMap<ArticuloDTO, Servicio>()
                .ForMember(dest => dest.TipoArticulo, opt => opt.MapFrom(src => TipoArticulo.Servicio));
            */

            //Producto
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Producto, ProductoCreateDTO>().ReverseMap();
            CreateMap<Producto, ProductoUpdateDTO>()
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ReverseMap();

            //Servicio
            CreateMap<Servicio, ServicioDTO>().ForMember(dest => dest.ArticuloId, opt => opt.MapFrom(src => src.ArticuloId)).ReverseMap();
            CreateMap<Servicio, ServicioCreateDTO>().ReverseMap();

            //Usuario
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();


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
               .ForMember(dest => dest.FechaFinVigencia, opt => opt.MapFrom(src => src.FechaFinVigencia))
               .ReverseMap();

            // Mapeo entre TimbradoCreateDTO y Timbrado
            CreateMap<TimbradoCreateDTO, Timbrado>()
                .ForMember(dest => dest.FechaInicioVigencia, opt => opt.MapFrom(src => src.FechaInicioVigencia.Date))
                .ForMember(dest => dest.TipoTimbrado, opt => opt.MapFrom(src => src.TipoTimbrado.ToString()))
                .ForMember(dest => dest.FechaFinVigencia, opt => opt.MapFrom(src => src.FechaFinVigencia));

            // Rango timbrado
            CreateMap<Rango_Timbrados, RangoTimbradoDTO>().ReverseMap();
            CreateMap<Rango_Timbrados, RangoTimbradoCreateDTO>().ReverseMap();

            //Ciudad
            CreateMap<Ciudad, CiudadDTO>().ReverseMap();
            CreateMap<Ciudad, CiudadCreateDTO>().ReverseMap();

            //TipoDocumentoIdentidad,
            CreateMap<TipoDocumentoIdentidad, TablaMenorCreateDTO>().ReverseMap();
            CreateMap<TipoDocumentoIdentidad, TablaMenorDTO>().ReverseMap();

            //Cliente,
            CreateMap<Persona, ClienteDTO>().ReverseMap();
            CreateMap<Persona, ClienteCreateDTO>().ReverseMap();

            //Venta
            CreateMap<Venta, VentaDTO>().ReverseMap();
            CreateMap<VentaCreateDTO, Venta>().ReverseMap();



            //Detalle Venta
            CreateMap<DetalleVenta, DetalleVentaDTO>().ReverseMap();
            CreateMap<DetalleVentaCreateDTO, DetalleVenta>()
            .ForMember(dest => dest.IdDetalle, opt => opt.MapFrom(src => src.IdDetalle))
            .ForMember(dest => dest.VentaId, opt => opt.MapFrom(src => src.NroVenta))
            .ForMember(dest => dest.NroItem, opt => opt.MapFrom(src => src.NroItem))
            .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
            .ForMember(dest => dest.TipoimpuestoId, opt => opt.MapFrom(src => src.TipoimpuestoId))
            .ForMember(dest => dest.ImporteIVA, opt => opt.MapFrom(src => src.ImporteIVA))
            .ForMember(dest => dest.ImporteGravado, opt => opt.MapFrom(src => src.ImporteGravado))
            .ForMember(dest => dest.ImporteExento, opt => opt.MapFrom(src => src.ImporteExento))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom<ItemIdResolver>())
            .ForMember(dest => dest.TipoItem, opt => opt.MapFrom(src => src.TipoItem))

            // Ignorar las propiedades de navegación para evitar problemas de tracking
            .ForMember(dest => dest.Venta, opt => opt.Ignore())
            .ForMember(dest => dest.TipoImpuesto, opt => opt.Ignore());

            //Ubicación
            CreateMap<Ubicacion, UbicacionDTO>().ReverseMap();
            CreateMap<Ubicacion, UbicacionCreateDTO>().ReverseMap();

            //Sucursal
            CreateMap<Sucursal, SucursalCreateDTO>().ReverseMap();
            CreateMap<Sucursal, SucursalDTO>().ReverseMap();


            //Stock
            CreateMap<Stock, StockAddDTO>().ReverseMap();
            CreateMap<Stock, StockDTO>().ReverseMap();
        }
    }
}
