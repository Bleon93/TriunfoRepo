using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class DetalleParametro
    {
        public DetalleParametro()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
            Persona = new HashSet<Persona>();
            PqrTipoDocumentoNavigation = new HashSet<Pqr>();
            PqrTipoSolicitudNavigation = new HashSet<Pqr>();
            Producto = new HashSet<Producto>();
        }

        public int IdDetParametro { get; set; }
        public int? IdParametro { get; set; }
        public int? ValorNumDetParametro { get; set; }
        public string ValorStringDetParametro { get; set; }
        public string DescripcionDetParametro { get; set; }
        public bool? EstadoDetParametro { get; set; }

        public virtual Parametro IdParametroNavigation { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<Pqr> PqrTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Pqr> PqrTipoSolicitudNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
