using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class addControlTemperatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_temperaturaPacientes_pacientes_PacienteId",
                table: "temperaturaPacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_temperaturaPacientes",
                table: "temperaturaPacientes");

            migrationBuilder.RenameTable(
                name: "temperaturaPacientes",
                newName: "ControlTemperatura");

            migrationBuilder.RenameIndex(
                name: "IX_temperaturaPacientes_PacienteId",
                table: "ControlTemperatura",
                newName: "IX_ControlTemperatura_PacienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlTemperatura",
                table: "ControlTemperatura",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlTemperatura_pacientes_PacienteId",
                table: "ControlTemperatura",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlTemperatura_pacientes_PacienteId",
                table: "ControlTemperatura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlTemperatura",
                table: "ControlTemperatura");

            migrationBuilder.RenameTable(
                name: "ControlTemperatura",
                newName: "temperaturaPacientes");

            migrationBuilder.RenameIndex(
                name: "IX_ControlTemperatura_PacienteId",
                table: "temperaturaPacientes",
                newName: "IX_temperaturaPacientes_PacienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_temperaturaPacientes",
                table: "temperaturaPacientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_temperaturaPacientes_pacientes_PacienteId",
                table: "temperaturaPacientes",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
