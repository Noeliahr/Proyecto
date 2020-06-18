using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class Eliminar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pacientes_termometros_TermometroId",
                table: "pacientes");

            migrationBuilder.DropTable(
                name: "termometros");

            migrationBuilder.DropIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes");

            migrationBuilder.DropColumn(
                name: "Temperatura_Media",
                table: "pacientes");

            migrationBuilder.DropColumn(
                name: "TermometroId",
                table: "pacientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Temperatura_Media",
                table: "pacientes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TermometroId",
                table: "pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "termometros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termometros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes",
                column: "TermometroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pacientes_termometros_TermometroId",
                table: "pacientes",
                column: "TermometroId",
                principalTable: "termometros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
