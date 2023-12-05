using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_API.Modelos.DTO
{
    public class ProductoDTO
    {   public int Articulonro { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }

        public TipoArticulo Tipoarticulo { get; set; }

        public DateTime Fecharegistro { get; set; }

        public DateTime? Fechaultactualizacion { get; set; }

        public int TipoimpuestoId { get; set; }

        [ForeignKey(nameof(TipoimpuestoId))]
        public TipoImpuesto TipoImpuesto { get; set; }
        public string Codigobarra { get; set; }
        public int? Stockminimo { get; set; }
        public int Stockactual { get; set; }
        public double PrecioCompra { get; set; }
        public DateOnly? Fechavencimiento { get; set; }
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
