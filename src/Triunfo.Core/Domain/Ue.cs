using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Ue
    {
        public int IdUe { get; set; }
        public int? IdPersona { get; set; }
        public int? RolUsuario { get; set; }
        public string Clave { get; set; }
        public bool? Estado { get; set; }
    }
}
