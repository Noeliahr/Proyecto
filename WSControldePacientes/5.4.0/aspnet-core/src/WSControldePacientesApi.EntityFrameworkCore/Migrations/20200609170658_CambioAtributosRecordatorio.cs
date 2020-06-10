using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class CambioAtributosRecordatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recordatorios_prescripciones_PrescripcionId",
                table: "recordatorios");

            migrationBuilder.AlterColumn<int>(
                name: "PrescripcionId",
                table: "recordatorios",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHora",
                table: "recordatorios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "recordatorios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_recordatorios_PacienteId",
                table: "recordatorios",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_recordatorios_pacientes_PacienteId",
                table: "recordatorios",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_recordatorios_prescripciones_PrescripcionId",
            //    table: "recordatorios",
            //    column: "PrescripcionId",
            //    principalTable: "prescripciones",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recordatorios_pacientes_PacienteId",
                table: "recordatorios");

            migrationBuilder.DropForeignKey(
                name: "FK_recordatorios_prescripciones_PrescripcionId",
                table: "recordatorios");

            migrationBuilder.DropIndex(
                name: "IX_recordatorios_PacienteId",
                table: "recordatorios");

            migrationBuilder.DropColumn(
                name: "FechaHora",
                table: "recordatorios");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "recordatorios");

            migrationBuilder.AlterColumn<int>(
                name: "PrescripcionId",
                table: "recordatorios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_recordatorios_prescripciones_PrescripcionId",
                table: "recordatorios",
                column: "PrescripcionId",
                principalTable: "prescripciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
