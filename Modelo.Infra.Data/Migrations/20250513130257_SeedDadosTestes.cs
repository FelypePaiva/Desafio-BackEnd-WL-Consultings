using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDadosTestes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nome", "numeroConta", "saldo", "senha" },
                values: new object[] { 1, "Irineu", "321", 500.5, "caf1a3dfb505ffed0d024130f58c5cfa" });
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nome", "numeroConta", "saldo", "senha" },
                values: new object[] { 2, "Isadora", "123", 225.2, "202cb962ac59075b964b07152d234b70" });

            migrationBuilder.InsertData(
               table: "Transferencias",
               columns: new[] { "Id", "RemetenteId", "DestinatarioId", "valorTransferencia", "DataTransferencia" },
               values: new object[] { 1, 1, 2, 25.1, new DateTime(2025, 05, 10) });

            migrationBuilder.InsertData(
               table: "Transferencias",
               columns: new[] { "Id", "RemetenteId", "DestinatarioId", "valorTransferencia", "DataTransferencia" },
               values: new object[] { 2, 2, 1, 52.6, new DateTime(2025, 05, 11) });

            migrationBuilder.InsertData(
               table: "Transferencias",
               columns: new[] { "Id", "RemetenteId", "DestinatarioId", "valorTransferencia", "DataTransferencia" },
               values: new object[] { 3, 1, 2, 52.6, new DateTime(2025, 05, 11) });
            migrationBuilder.InsertData(
               table: "Transferencias",
               columns: new[] { "Id", "RemetenteId", "DestinatarioId", "valorTransferencia", "DataTransferencia" },
               values: new object[] { 4, 2, 1, 15.8, new DateTime(2025, 05, 12) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
