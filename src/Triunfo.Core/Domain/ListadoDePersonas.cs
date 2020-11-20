using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class ListadoDePersonas
    {
        public int IdPersona { get; set; }
        public string NombresYApellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NDeDocumento { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string RazonSocial { get; set; }
    }
}
