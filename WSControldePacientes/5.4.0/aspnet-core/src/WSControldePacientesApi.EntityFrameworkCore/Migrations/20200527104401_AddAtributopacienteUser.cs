using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class AddAtributopacienteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pacienteId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_pacienteId",
                table: "AbpUsers",
                column: "pacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_pacientes_pacienteId",
                table: "AbpUsers",
                column: "pacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_pacientes_pacienteId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_pacienteId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "pacienteId",
                table: "AbpUsers");
        }
    }
}
