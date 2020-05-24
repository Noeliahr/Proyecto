using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class UserMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "medicoId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_medicoId",
                table: "AbpUsers",
                column: "medicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_medicos_medicoId",
                table: "AbpUsers",
                column: "medicoId",
                principalTable: "medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_medicos_medicoId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_medicoId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "direcciones");

            migrationBuilder.DropColumn(
                name: "medicoId",
                table: "AbpUsers");

            migrationBuilder.AddColumn<string>(
                name: "Codigo_Postal",
                table: "direcciones",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
