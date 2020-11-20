using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class ListadoDeUsuarios
    {
        public int IdUsuario { get; set; }
        public string NombresYApellidos { get; set; }
        public string RollDeUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Clave { get; set; }
    }
}
