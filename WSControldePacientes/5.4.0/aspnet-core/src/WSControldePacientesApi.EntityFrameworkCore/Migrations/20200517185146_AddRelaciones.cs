using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class AddRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_responsables_DatosPersonalesId",
                table: "responsables");

            migrationBuilder.DropIndex(
                name: "IX_pacientes_DatosPersonalesId",
                table: "pacientes");

            migrationBuilder.DropIndex(
                name: "IX_medicos_DatosPersonalesId",
                table: "medicos");

            migrationBuilder.CreateIndex(
                name: "IX_responsables_DatosPersonalesId",
                table: "responsables",
                column: "DatosPersonalesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_DatosPersonalesId",
                table: "pacientes",
                column: "DatosPersonalesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicos_DatosPersonalesId",
                table: "medicos",
                column: "DatosPersonalesId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_responsables_DatosPersonalesId",
                table: "responsables");

            migrationBuilder.DropIndex(
                name: "IX_pacientes_DatosPersonalesId",
                table: "pacientes");

            migrationBuilder.DropIndex(
                name: "IX_medicos_DatosPersonalesId",
                table: "medicos");

            migrationBuilder.CreateIndex(
                name: "IX_responsables_DatosPersonalesId",
                table: "responsables",
                column: "DatosPersonalesId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_DatosPersonalesId",
                table: "pacientes",
                column: "DatosPersonalesId");

            migrationBuilder.CreateIndex(
                name: "IX_medicos_DatosPersonalesId",
                table: "medicos",
                column: "DatosPersonalesId");
        }
    }
}
