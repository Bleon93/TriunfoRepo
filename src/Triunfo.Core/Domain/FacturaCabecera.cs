using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class FacturaCabecera
    {
        public FacturaCabecera()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
        }

        public int IdFactura { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public DateTime? FechaFactura { get; set; }

        public virtual Persona IdClienteNavigation { get; set; }
        public virtual Persona IdVendedorNavigation { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
