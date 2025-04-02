using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Model.Modelos
{
    public class MovimientoStock
    {
        public int Id { get; set; }

        // Relaciones
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public int UbicacionId { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }

        // Datos del movimiento
        public int Cantidad { get; set; } // Positivo para entradas, negativo para salidas
        public decimal PrecioUnitario { get; set; } // Precio en el momento del movimiento
        public DateTime FechaMovimiento { get; set; } = DateTime.Now;

        // Tipo de movimiento (compra, venta, ajuste, etc.)
        public TipoMovimientoStock TipoMovimiento { get; set; }

        // Referencia al documento origen (opcional)
        public string DocumentoReferencia { get; set; }
        public int? ReferenciaId { get; set; } // ID de la venta/compra/ajuste relacionado

        // Auditoría
        public string UsuarioId { get; set; } // Quién realizó el movimiento
        public string Comentarios { get; set; }
    }


    public enum TipoMovimientoStock
    {
        Compra,
        Venta,
        AjusteEntrada,
        AjusteSalida,
        TransferenciaEntrada,
        TransferenciaSalida,
        Devolucion,
        Perdida,
        InventarioInicial
    }
}
