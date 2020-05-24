using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class AddRelaciones1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes",
                column: "TermometroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes",
                column: "TermometroId");
        }
    }
}
