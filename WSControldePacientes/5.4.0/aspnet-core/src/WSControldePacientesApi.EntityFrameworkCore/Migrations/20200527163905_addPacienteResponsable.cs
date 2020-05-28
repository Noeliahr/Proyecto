using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class addPacienteResponsable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacienteResponsable_pacientes_PacienteId",
                table: "PacienteResponsable");

            migrationBuilder.DropForeignKey(
                name: "FK_PacienteResponsable_responsables_ResponsableId",
                table: "PacienteResponsable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteResponsable",
                table: "PacienteResponsable");

            migrationBuilder.RenameTable(
                name: "PacienteResponsable",
                newName: "pacienteResponsables");

            migrationBuilder.RenameIndex(
                name: "IX_PacienteResponsable_ResponsableId",
                table: "pacienteResponsables",
                newName: "IX_pacienteResponsables_ResponsableId");

            migrationBuilder.RenameIndex(
                name: "IX_PacienteResponsable_PacienteId",
                table: "pacienteResponsables",
                newName: "IX_pacienteResponsables_PacienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pacienteResponsables",
                table: "pacienteResponsables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pacienteResponsables_pacientes_PacienteId",
                table: "pacienteResponsables",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_pacienteResponsables_responsables_ResponsableId",
                table: "pacienteResponsables",
                column: "ResponsableId",
                principalTable: "responsables",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pacienteResponsables_pacientes_PacienteId",
                table: "pacienteResponsables");

            migrationBuilder.DropForeignKey(
                name: "FK_pacienteResponsables_responsables_ResponsableId",
                table: "pacienteResponsables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pacienteResponsables",
                table: "pacienteResponsables");

            migrationBuilder.RenameTable(
                name: "pacienteResponsables",
                newName: "PacienteResponsable");

            migrationBuilder.RenameIndex(
                name: "IX_pacienteResponsables_ResponsableId",
                table: "PacienteResponsable",
                newName: "IX_PacienteResponsable_ResponsableId");

            migrationBuilder.RenameIndex(
                name: "IX_pacienteResponsables_PacienteId",
                table: "PacienteResponsable",
                newName: "IX_PacienteResponsable_PacienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteResponsable",
                table: "PacienteResponsable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteResponsable_pacientes_PacienteId",
                table: "PacienteResponsable",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteResponsable_responsables_ResponsableId",
                table: "PacienteResponsable",
                column: "ResponsableId",
                principalTable: "responsables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
