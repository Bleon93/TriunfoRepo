using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdPersona { get; set; }
        public int? RolUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public bool? EstadoUsuario { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
