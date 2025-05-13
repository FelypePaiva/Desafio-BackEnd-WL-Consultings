using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Usuarios",
                newName: "senha");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Usuarios",
                newName: "Name");
        }
    }
}
