using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class ListadoDeProductos
    {
        public int Id { get; set; }
        public string NombreDeProducto { get; set; }
        public int? PrecioDeVenta { get; set; }
        public string Categoria { get; set; }
    }
}
