using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionaCamposUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "numeroConta");

            migrationBuilder.AddColumn<decimal>(
                name: "saldo",
                table: "Usuarios",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "saldo",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "numeroConta",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
