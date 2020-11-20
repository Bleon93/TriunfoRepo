using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Parametro
    {
        public Parametro()
        {
            DetalleParametro = new HashSet<DetalleParametro>();
        }

        public int IdParametro { get; set; }
        public string DescripcionParametro { get; set; }

        public virtual ICollection<DetalleParametro> DetalleParametro { get; set; }
    }
}
