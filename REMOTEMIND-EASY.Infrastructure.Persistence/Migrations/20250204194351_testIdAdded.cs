using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class testIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "RespuestaDeUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestId",
                table: "RespuestaDeUsuario");
        }
    }
}
