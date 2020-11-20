using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Triunfo.Core.Domain;

namespace Triunfo.Infrastructure.Data
{
    public partial class TriunfoDbContext : DbContext
    {
        public TriunfoDbContext()
        {
        }

        public TriunfoDbContext(DbContextOptions<TriunfoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleParametro> DetalleParametro { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<FacturaCabecera> FacturaCabecera { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<ListadoDePersonas> ListadoDePersonas { get; set; }
        public virtual DbSet<ListadoDeProductos> ListadoDeProductos { get; set; }
        public virtual DbSet<ListadoDeUsuarios> ListadoDeUsuarios { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Pe> Pe { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonasConCedula> PersonasConCedula { get; set; }
        public virtual DbSet<PersonasConNit> PersonasConNit { get; set; }
        public virtual DbSet<Pqr> Pqr { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Ue> Ue { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //if (!optionsBuilder.IsConfigured)
            //{
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseMySQL("database=triunfo;server=localhost;port=3306;user id=root;password=");
    //        }
      } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleParametro>(entity =>
            {
                entity.HasKey(e => e.IdDetParametro)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_parametro");

                entity.HasIndex(e => e.IdParametro)
                    .HasName("FK_DetParametro_Parametro");

                entity.Property(e => e.IdDetParametro)
                    .HasColumnName("Id_Det_Parametro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DescripcionDetParametro)
                    .HasColumnName("Descripcion_Det_Parametro")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EstadoDetParametro)
                    .HasColumnName("Estado_Det_Parametro")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("Id_Parametro")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ValorNumDetParametro)
                    .HasColumnName("Valor_Num_Det_Parametro")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ValorStringDetParametro)
                    .HasColumnName("Valor_String_Det_Parametro")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdParametroNavigation)
                    .WithMany(p => p.DetalleParametro)
                    .HasForeignKey(d => d.IdParametro)
                    .HasConstraintName("FK_DetParametro_Parametro");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<FacturaCabecera>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("factura_cabecera");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("FK_FacturaC_Persona");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("FK_FacturaC_Persona2");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("Id_Factura")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFactura)
                    .HasColumnName("Fecha_Factura")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("Id_Cliente")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("Id_Vendedor")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.FacturaCabeceraIdClienteNavigation)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_FacturaC_Persona");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.FacturaCabeceraIdVendedorNavigation)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_FacturaC_Persona2");
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDet)
                    .HasName("PRIMARY");

                entity.ToTable("factura_detalle");

                entity.HasIndex(e => e.Descuento)
                    .HasName("FK_FacturaDet_DetParametro");

                entity.HasIndex(e => e.IdFactura)
                    .HasName("FK_FacturaDet_FacturaC");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("FK_FacturaDet_Producto");

                entity.Property(e => e.IdFacturaDet)
                    .HasColumnName("Id_Factura_Det")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadProducto)
                    .HasColumnName("Cantidad_Producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Descuento)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("Id_Factura")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnName("Valor_Unitario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DescuentoNavigation)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.Descuento)
                    .HasConstraintName("FK_FacturaDet_DetParametro");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_FacturaDet_FacturaC");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_FacturaDet_Producto");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PRIMARY");

                entity.ToTable("inventario");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("FK_Inventario_Producto");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("FK_Inventario_Persona");

                entity.Property(e => e.IdInventario)
                    .HasColumnName("Id_Inventario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("Id_Proveedor")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrecioLlegada)
                    .HasColumnName("Precio_Llegada")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Inventario_Producto");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Inventario_Persona");
            });

            modelBuilder.Entity<ListadoDePersonas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("listado de personas");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("Correo electronico")
                    .HasMaxLength(50);

                entity.Property(e => e.IdPersona)
                    .HasColumnName("Id_Persona")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NDeDocumento)
                    .IsRequired()
                    .HasColumnName("N° de documento")
                    .HasMaxLength(50);

                entity.Property(e => e.NombresYApellidos)
                    .IsRequired()
                    .HasColumnName("Nombres y apellidos")
                    .HasMaxLength(101)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("Razon social")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("Tipo Documento")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ListadoDeProductos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("listado de productos");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreDeProducto)
                    .HasColumnName("Nombre de producto")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrecioDeVenta)
                    .HasColumnName("Precio de venta")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ListadoDeUsuarios>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("listado de usuarios");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("Correo electronico")
                    .HasMaxLength(50);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombresYApellidos)
                    .IsRequired()
                    .HasColumnName("Nombres y apellidos")
                    .HasMaxLength(101)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.RollDeUsuario)
                    .HasColumnName("Roll de usuario")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PRIMARY");

                entity.ToTable("parametro");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("Id_Parametro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DescripcionParametro)
                    .HasColumnName("Descripcion_Parametro")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Pe>(entity =>
            {
                entity.HasKey(e => e.IdPe)
                    .HasName("PRIMARY");

                entity.ToTable("pe");

                entity.Property(e => e.IdPe)
                    .HasColumnName("id_PE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApellidoPersona)
                    .HasColumnName("Apellido_persona")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CorreoPersona)
                    .HasColumnName("Correo_persona")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombrePersona)
                    .HasColumnName("Nombre_persona")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NumDocPersona)
                    .HasColumnName("Num_Doc_Persona")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("Razon_social")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TelefonoPersona)
                    .HasColumnName("Telefono_persona")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TipoDocPersona)
                    .HasColumnName("Tipo_Doc_persona")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PRIMARY");

                entity.ToTable("persona");

                entity.HasIndex(e => new { e.TipoDocPersona, e.NumDocPersona })
                    .HasName("Tipo_Doc_Persona_Num_Doc_Persona");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("Id_Persona")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApellidoPersona)
                    .IsRequired()
                    .HasColumnName("Apellido_Persona")
                    .HasMaxLength(50);

                entity.Property(e => e.CorreoPersona)
                    .IsRequired()
                    .HasColumnName("Correo_Persona")
                    .HasMaxLength(50);

                entity.Property(e => e.NombrePersona)
                    .IsRequired()
                    .HasColumnName("Nombre_Persona")
                    .HasMaxLength(50);

                entity.Property(e => e.NumDocPersona)
                    .IsRequired()
                    .HasColumnName("Num_Doc_Persona")
                    .HasMaxLength(50);

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("Razon_Social")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TelefonoPersona)
                    .HasColumnName("Telefono_Persona")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TipoDocPersona)
                    .HasColumnName("Tipo_Doc_Persona")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TipoDocPersonaNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.TipoDocPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_DetParametro");
            });

            modelBuilder.Entity<PersonasConCedula>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("personas con cedula");

                entity.Property(e => e.NDeDocumento)
                    .IsRequired()
                    .HasColumnName("N° DE DOCUMENTO")
                    .HasMaxLength(50);

                entity.Property(e => e.NombresYApellidos)
                    .IsRequired()
                    .HasColumnName("Nombres y apellidos")
                    .HasMaxLength(101)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("Tipo Documento")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<PersonasConNit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("personas con nit");

                entity.Property(e => e.NDeDocumento)
                    .IsRequired()
                    .HasColumnName("N° DE DOCUMENTO")
                    .HasMaxLength(50);

                entity.Property(e => e.NombresYApellidos)
                    .IsRequired()
                    .HasColumnName("Nombres y apellidos")
                    .HasMaxLength(101)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("Tipo Documento")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Pqr>(entity =>
            {
                entity.HasKey(e => e.IdPqr)
                    .HasName("PRIMARY");

                entity.ToTable("pqr");

                entity.HasIndex(e => e.TipoDocumento)
                    .HasName("FK1");

                entity.HasIndex(e => e.TipoSolicitud)
                    .HasName("FK_pqr_detalle_parametro");

                entity.Property(e => e.IdPqr)
                    .HasColumnName("Id_pqr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EMail)
                    .HasColumnName("E_mail")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NumDocumento)
                    .HasColumnName("Num_Documento")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("Tipo_Documento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoSolicitud)
                    .HasColumnName("Tipo_solicitud")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.TipoDocumentoNavigation)
                    .WithMany(p => p.PqrTipoDocumentoNavigation)
                    .HasForeignKey(d => d.TipoDocumento)
                    .HasConstraintName("FK1");

                entity.HasOne(d => d.TipoSolicitudNavigation)
                    .WithMany(p => p.PqrTipoSolicitudNavigation)
                    .HasForeignKey(d => d.TipoSolicitud)
                    .HasConstraintName("FK_pqr_detalle_parametro");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.CategoriaProducto)
                    .HasName("FK_Producto_DetParametro");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaProducto)
                    .HasColumnName("Categoria_Producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IvaProducto)
                    .HasColumnName("Iva_Producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreProducto)
                    .HasColumnName("Nombre_Producto")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrecioSalidaPro)
                    .HasColumnName("Precio_Salida_Pro")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CategoriaProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaProducto)
                    .HasConstraintName("FK_Producto_DetParametro");
            });

            modelBuilder.Entity<Ue>(entity =>
            {
                entity.HasKey(e => e.IdUe)
                    .HasName("PRIMARY");

                entity.ToTable("ue");

                entity.Property(e => e.IdUe)
                    .HasColumnName("id_UE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clave)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Estado)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("ID_PERSONA")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RolUsuario)
                    .HasColumnName("Rol_usuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdPersona)
                    .HasName("FK_Usuario_Persona");

                entity.HasIndex(e => e.RolUsuario)
                    .HasName("FK_Usuario_DetParametro");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClaveUsuario)
                    .HasColumnName("Clave_Usuario")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EstadoUsuario)
                    .HasColumnName("Estado_Usuario")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("Id_Persona")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RolUsuario)
                    .HasColumnName("Rol_Usuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_Usuario_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
