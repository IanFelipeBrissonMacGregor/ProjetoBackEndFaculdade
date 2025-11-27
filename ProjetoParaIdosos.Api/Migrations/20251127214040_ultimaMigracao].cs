using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoParaIdosos.Api.Migrations
{
    /// <inheritdoc />
    public partial class ultimaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Certificações",
                table: "Partners",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qualificação",
                table: "Partners",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificações",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "Qualificação",
                table: "Partners");
        }
    }
}
