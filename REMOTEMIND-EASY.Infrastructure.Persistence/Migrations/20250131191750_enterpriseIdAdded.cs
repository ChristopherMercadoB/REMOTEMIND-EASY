using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class enterpriseIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Resultado",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Resultado");
        }
    }
}
