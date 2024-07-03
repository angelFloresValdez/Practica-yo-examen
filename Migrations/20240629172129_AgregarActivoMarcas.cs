using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConexionEF.Migrations
{
    /// <inheritdoc />
    public partial class AgregarActivoMarcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "MarcasProductos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "MarcasProductos");
        }
    }
}
