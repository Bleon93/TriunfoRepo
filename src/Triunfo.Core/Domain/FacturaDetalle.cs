using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class FacturaDetalle
    {
        public int IdFacturaDet { get; set; }
        public int? IdFactura { get; set; }
        public int? IdProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public int? ValorUnitario { get; set; }
        public int? Descuento { get; set; }

        public virtual DetalleParametro DescuentoNavigation { get; set; }
        public virtual FacturaCabecera IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
