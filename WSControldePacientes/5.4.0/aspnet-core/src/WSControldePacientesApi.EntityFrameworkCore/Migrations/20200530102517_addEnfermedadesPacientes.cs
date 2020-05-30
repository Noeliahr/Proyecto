using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class addEnfermedadesPacientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnfermedadPaciente_enfermedades_EnfermedadId",
                table: "EnfermedadPaciente");

            migrationBuilder.DropForeignKey(
                name: "FK_EnfermedadPaciente_pacientes_PacienteId",
                table: "EnfermedadPaciente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnfermedadPaciente",
                table: "EnfermedadPaciente");

            migrationBuilder.RenameTable(
                name: "EnfermedadPaciente",
                newName: "enfermedadPacientes");

            migrationBuilder.RenameIndex(
                name: "IX_EnfermedadPaciente_PacienteId",
                table: "enfermedadPacientes",
                newName: "IX_enfermedadPacientes_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_EnfermedadPaciente_EnfermedadId",
                table: "enfermedadPacientes",
                newName: "IX_enfermedadPacientes_EnfermedadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enfermedadPacientes",
                table: "enfermedadPacientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enfermedadPacientes_enfermedades_EnfermedadId",
                table: "enfermedadPacientes",
                column: "EnfermedadId",
                principalTable: "enfermedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enfermedadPacientes_pacientes_PacienteId",
                table: "enfermedadPacientes",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enfermedadPacientes_enfermedades_EnfermedadId",
                table: "enfermedadPacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_enfermedadPacientes_pacientes_PacienteId",
                table: "enfermedadPacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enfermedadPacientes",
                table: "enfermedadPacientes");

            migrationBuilder.RenameTable(
                name: "enfermedadPacientes",
                newName: "EnfermedadPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_enfermedadPacientes_PacienteId",
                table: "EnfermedadPaciente",
                newName: "IX_EnfermedadPaciente_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_enfermedadPacientes_EnfermedadId",
                table: "EnfermedadPaciente",
                newName: "IX_EnfermedadPaciente_EnfermedadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnfermedadPaciente",
                table: "EnfermedadPaciente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnfermedadPaciente_enfermedades_EnfermedadId",
                table: "EnfermedadPaciente",
                column: "EnfermedadId",
                principalTable: "enfermedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnfermedadPaciente_pacientes_PacienteId",
                table: "EnfermedadPaciente",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
