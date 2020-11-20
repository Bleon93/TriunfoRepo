using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Pqr
    {
        public int IdPqr { get; set; }
        public int? TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string EMail { get; set; }
        public string Telefono { get; set; }
        public int? TipoSolicitud { get; set; }
        public string Mensaje { get; set; }

        public virtual DetalleParametro TipoDocumentoNavigation { get; set; }
        public virtual DetalleParametro TipoSolicitudNavigation { get; set; }
    }
}
