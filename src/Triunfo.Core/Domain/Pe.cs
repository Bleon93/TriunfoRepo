using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Pe
    {
        public int IdPe { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string TelefonoPersona { get; set; }
        public string CorreoPersona { get; set; }
        public int? TipoDocPersona { get; set; }
        public string NumDocPersona { get; set; }
        public string RazonSocial { get; set; }
    }
}
