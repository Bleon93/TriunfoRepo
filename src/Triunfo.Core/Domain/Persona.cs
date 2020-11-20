using System;
using System.Collections.Generic;

namespace Triunfo.Core.Domain
{
    public partial class Persona
    {
        public Persona()
        {
            FacturaCabeceraIdClienteNavigation = new HashSet<FacturaCabecera>();
            FacturaCabeceraIdVendedorNavigation = new HashSet<FacturaCabecera>();
            Inventario = new HashSet<Inventario>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string TelefonoPersona { get; set; }
        public string CorreoPersona { get; set; }
        public int TipoDocPersona { get; set; }
        public string NumDocPersona { get; set; }
        public string RazonSocial { get; set; }

        public virtual DetalleParametro TipoDocPersonaNavigation { get; set; }
        public virtual ICollection<FacturaCabecera> FacturaCabeceraIdClienteNavigation { get; set; }
        public virtual ICollection<FacturaCabecera> FacturaCabeceraIdVendedorNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
