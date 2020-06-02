using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class cambiarAtributosMedicamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Componente_Base",
                table: "medicamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Dosis",
                table: "prescripciones",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Gramaje",
                table: "medicamentos",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "ComponenteBase",
                table: "medicamentos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponenteBase",
                table: "medicamentos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Dosis",
                table: "prescripciones",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<decimal>(
                name: "Gramaje",
                table: "medicamentos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Componente_Base",
                table: "medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
