using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addingForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaDeUsuario_Preguntas_QuestionId",
                table: "RespuestaDeUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaDeUsuario_Respuestas_ResponseId",
                table: "RespuestaDeUsuario");

            migrationBuilder.DropTable(
                name: "QuestionsResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RespuestaDeUsuario",
                table: "RespuestaDeUsuario");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RespuestaDeUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RespuestaDeUsuario",
                table: "RespuestaDeUsuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaDeUsuario_ResponseId",
                table: "RespuestaDeUsuario",
                column: "ResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaDeUsuario_Preguntas_QuestionId",
                table: "RespuestaDeUsuario",
                column: "QuestionId",
                principalTable: "Preguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaDeUsuario_Respuestas_ResponseId",
                table: "RespuestaDeUsuario",
                column: "ResponseId",
                principalTable: "Respuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaDeUsuario_Preguntas_QuestionId",
                table: "RespuestaDeUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaDeUsuario_Respuestas_ResponseId",
                table: "RespuestaDeUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RespuestaDeUsuario",
                table: "RespuestaDeUsuario");

            migrationBuilder.DropIndex(
                name: "IX_RespuestaDeUsuario_ResponseId",
                table: "RespuestaDeUsuario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RespuestaDeUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RespuestaDeUsuario",
                table: "RespuestaDeUsuario",
                columns: new[] { "ResponseId", "QuestionId" });

            migrationBuilder.CreateTable(
                name: "QuestionsResponses",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    ResponsesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsResponses", x => new { x.QuestionsId, x.ResponsesId });
                    table.ForeignKey(
                        name: "FK_QuestionsResponses_Preguntas_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsResponses_Respuestas_ResponsesId",
                        column: x => x.ResponsesId,
                        principalTable: "Respuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsResponses_ResponsesId",
                table: "QuestionsResponses",
                column: "ResponsesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaDeUsuario_Preguntas_QuestionId",
                table: "RespuestaDeUsuario",
                column: "QuestionId",
                principalTable: "Preguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaDeUsuario_Respuestas_ResponseId",
                table: "RespuestaDeUsuario",
                column: "ResponseId",
                principalTable: "Respuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
