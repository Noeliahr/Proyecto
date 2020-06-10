using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class CambioAtributosRecordatorio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_recordatorios_prescripciones_PrescripcionId",
            //    table: "recordatorios");

            //migrationBuilder.DropIndex(
            //    name: "IX_recordatorios_PrescripcionId",
            //    table: "recordatorios");

            //migrationBuilder.DropColumn(
            //    name: "PrescripcionId",
            //    table: "recordatorios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescripcionId",
                table: "recordatorios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_recordatorios_PrescripcionId",
                table: "recordatorios",
                column: "PrescripcionId");

            migrationBuilder.AddForeignKey(
                name: "FK_recordatorios_prescripciones_PrescripcionId",
                table: "recordatorios",
                column: "PrescripcionId",
                principalTable: "prescripciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
