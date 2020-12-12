using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Triunfo.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                });

            migrationBuilder.CreateTable(
                name: "parametro",
                columns: table => new
                {
                    Id_Parametro = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion_Parametro = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Parametro);
                });

            migrationBuilder.CreateTable(
                name: "pe",
                columns: table => new
                {
                    id_PE = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_persona = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    Apellido_persona = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    Telefono_persona = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    Correo_persona = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    Tipo_Doc_persona = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Num_Doc_Persona = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    Razon_social = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_PE);
                });

            migrationBuilder.CreateTable(
                name: "ue",
                columns: table => new
                {
                    id_UE = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ID_PERSONA = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Rol_usuario = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Clave = table.Column<string>(maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    Estado = table.Column<bool>(type: "bit(1)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_UE);
                });

            migrationBuilder.CreateTable(
                name: "detalle_parametro",
                columns: table => new
                {
                    Id_Det_Parametro = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Parametro = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'"),
                    Valor_Num_Det_Parametro = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'"),
                    Valor_String_Det_Parametro = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Descripcion_Det_Parametro = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Estado_Det_Parametro = table.Column<bool>(type: "bit(1)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Det_Parametro);
                    table.ForeignKey(
                        name: "FK_DetParametro_Parametro",
                        column: x => x.Id_Parametro,
                        principalTable: "parametro",
                        principalColumn: "Id_Parametro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id_Persona = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Persona = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido_Persona = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono_Persona = table.Column<string>(maxLength: 15, nullable: true, defaultValueSql: "'NULL'"),
                    Correo_Persona = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo_Doc_Persona = table.Column<int>(type: "int(11)", nullable: false),
                    Num_Doc_Persona = table.Column<string>(maxLength: 50, nullable: false),
                    Razon_Social = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Persona);
                    table.ForeignKey(
                        name: "FK_Persona_DetParametro",
                        column: x => x.Tipo_Doc_Persona,
                        principalTable: "detalle_parametro",
                        principalColumn: "Id_Det_Parametro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pqr",
                columns: table => new
                {
                    Id_pqr = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tipo_Documento = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'"),
                    Num_Documento = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Nombres = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Apellidos = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    E_mail = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Telefono = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Tipo_solicitud = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'"),
                    Mensaje = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_pqr);
                    table.ForeignKey(
                        name: "FK1",
                        column: x => x.Tipo_Documento,
                        principalTable: "detalle_parametro",
                        principalColumn: "Id_Det_Parametro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pqr_detalle_parametro",
                        column: x => x.Tipo_solicitud,
                        principalTable: "detalle_parametro",
                        principalColumn: "Id_Det_Parametro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Producto = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Precio_Salida_Pro = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Categoria_Producto = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Iva_Producto = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Producto);
                    table.ForeignKey(
                        name: "FK_Producto_DetParametro",
                        column: x => x.Categoria_Producto,
                        principalTable: "detalle_parametro",
                        principalColumn: "Id_Det_Parametro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "factura_cabecera",
                columns: table => new
                {
                    Id_Factura = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Cliente = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Id_Vendedor = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Fecha_Factura = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'current_timestamp()'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Factura);
                    table.ForeignKey(
                        name: "FK_FacturaC_Persona",
                        column: x => x.Id_Cliente,
                        principalTable: "persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturaC_Persona2",
                        column: x => x.Id_Vendedor,
                        principalTable: "persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Persona = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'"),
                    Rol_Usuario = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'"),
                    Clave_Usuario = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Estado_Usuario = table.Column<bool>(type: "bit(1)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    Id_Inventario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Producto = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Id_Proveedor = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Stock = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Precio_Llegada = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Inventario);
                    table.ForeignKey(
                        name: "FK_Inventario_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventario_Persona",
                        column: x => x.Id_Proveedor,
                        principalTable: "persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "factura_detalle",
                columns: table => new
                {
                    Id_Factura_Det = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Factura = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Id_Producto = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Cantidad_Producto = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Valor_Unitario = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Descuento = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Factura_Det);
                    table.ForeignKey(
                        name: "FK_FacturaDet_DetParametro",
                        column: x => x.Descuento,
                        principalTable: "detalle_parametro",
                        principalColumn: "Id_Det_Parametro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturaDet_FacturaC",
                        column: x => x.Id_Factura,
                        principalTable: "factura_cabecera",
                        principalColumn: "Id_Factura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturaDet_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_DetParametro_Parametro",
                table: "detalle_parametro",
                column: "Id_Parametro");

            migrationBuilder.CreateIndex(
                name: "FK_FacturaC_Persona",
                table: "factura_cabecera",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "FK_FacturaC_Persona2",
                table: "factura_cabecera",
                column: "Id_Vendedor");

            migrationBuilder.CreateIndex(
                name: "FK_FacturaDet_DetParametro",
                table: "factura_detalle",
                column: "Descuento");

            migrationBuilder.CreateIndex(
                name: "FK_FacturaDet_FacturaC",
                table: "factura_detalle",
                column: "Id_Factura");

            migrationBuilder.CreateIndex(
                name: "FK_FacturaDet_Producto",
                table: "factura_detalle",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "FK_Inventario_Producto",
                table: "inventario",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "FK_Inventario_Persona",
                table: "inventario",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "Tipo_Doc_Persona_Num_Doc_Persona",
                table: "persona",
                columns: new[] { "Tipo_Doc_Persona", "Num_Doc_Persona" });

            migrationBuilder.CreateIndex(
                name: "FK1",
                table: "pqr",
                column: "Tipo_Documento");

            migrationBuilder.CreateIndex(
                name: "FK_pqr_detalle_parametro",
                table: "pqr",
                column: "Tipo_solicitud");

            migrationBuilder.CreateIndex(
                name: "FK_Producto_DetParametro",
                table: "producto",
                column: "Categoria_Producto");

            migrationBuilder.CreateIndex(
                name: "FK_Usuario_Persona",
                table: "usuario",
                column: "Id_Persona");

            migrationBuilder.CreateIndex(
                name: "FK_Usuario_DetParametro",
                table: "usuario",
                column: "Rol_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "factura_detalle");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "pe");

            migrationBuilder.DropTable(
                name: "pqr");

            migrationBuilder.DropTable(
                name: "ue");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "factura_cabecera");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "detalle_parametro");

            migrationBuilder.DropTable(
                name: "parametro");
        }
    }
}
