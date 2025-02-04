using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class eid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Resultado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Resultado");
        }
    }
}
