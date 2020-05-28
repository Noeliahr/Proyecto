using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class updateatributosDireccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entidad_de_Poblacion",
                table: "direcciones");

            migrationBuilder.DropColumn(
                name: "Km_en_la_via",
                table: "direcciones");

            migrationBuilder.AddColumn<string>(
                name: "EntidadePoblacion",
                table: "direcciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kmenlavia",
                table: "direcciones",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntidadePoblacion",
                table: "direcciones");

            migrationBuilder.DropColumn(
                name: "Kmenlavia",
                table: "direcciones");

            migrationBuilder.AddColumn<string>(
                name: "Entidad_de_Poblacion",
                table: "direcciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Km_en_la_via",
                table: "direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
