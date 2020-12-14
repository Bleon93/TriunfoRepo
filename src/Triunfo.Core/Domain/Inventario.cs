using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Triunfo.Core.Domain
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int? IdProducto { get; set; }
        public int? IdProveedor { get; set; }
        public int? Stock { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public int? PrecioLlegada { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Persona IdProveedorNavigation { get; set; }
    }
}
