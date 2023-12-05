using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFacturacion_Web.Models.DTO;

namespace SistemaFacturacion_Web.Models.ViewModel
{
    public class ProductoUpdateViewModel
    {
        public ProductoUpdateDTO Producto { get; set; }
        public IEnumerable<SelectListItem> MarcaLista { get; set; }
        public IEnumerable<SelectListItem> TipoImpuestoLista { get; set; }

        public ProductoUpdateViewModel()
        {
            Producto = new ProductoUpdateDTO();
        }
    }
}
