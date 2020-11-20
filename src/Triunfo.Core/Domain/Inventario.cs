using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int? IdProducto { get; set; }
        public int? IdProveedor { get; set; }
        public int? Stock { get; set; }
        public int? PrecioLlegada { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Persona IdProveedorNavigation { get; set; }
    }
}
