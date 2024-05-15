using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agenda_api.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Contatos",
                newName: "Telefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Contatos",
                newName: "telefone");
        }
    }
}
