using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Triunfo.Core.Domain
{
    public partial class Producto
    {
        public Producto()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
            Inventario = new HashSet<Inventario>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public int? PrecioSalidaPro { get; set; }
        public int? CategoriaProducto { get; set; }
        public int? IvaProducto { get; set; }

        public virtual DetalleParametro CategoriaProductoNavigation { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
