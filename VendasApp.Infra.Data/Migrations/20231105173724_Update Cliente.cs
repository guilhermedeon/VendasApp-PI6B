using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Cliente",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Cliente");
        }
    }
}