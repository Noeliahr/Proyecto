using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSControldePacientesApi.Migrations
{
    public partial class AddTodaslasTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Tipo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Letra = table.Column<string>(nullable: true),
                    Km_en_la_via = table.Column<int>(nullable: false),
                    Bloque = table.Column<string>(nullable: true),
                    Portal = table.Column<string>(nullable: true),
                    Escalera = table.Column<string>(nullable: true),
                    Planta = table.Column<int>(nullable: false),
                    Puerta = table.Column<string>(nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 5, nullable: false),
                    Entidad_de_Poblacion = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direcciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "enfermedades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    Sintomas = table.Column<string>(nullable: false),
                    Causas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enfermedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Gramaje = table.Column<decimal>(nullable: false),
                    Funcionalidad = table.Column<string>(nullable: false),
                    Componente_Base = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PersonaOrigenId = table.Column<long>(nullable: false),
                    PersonaDestinoId = table.Column<long>(nullable: false),
                    Texto = table.Column<string>(maxLength: 120, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    isLeido = table.Column<bool>(nullable: false),
                    isRecibido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mensajes_AbpUsers_PersonaDestinoId",
                        column: x => x.PersonaDestinoId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_mensajes_AbpUsers_PersonaOrigenId",
                        column: x => x.PersonaOrigenId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "responsables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DatosPersonalesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_responsables_AbpUsers_DatosPersonalesId",
                        column: x => x.DatosPersonalesId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "termometros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Fabricante = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termometros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DatosPersonalesId = table.Column<long>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    NumSeguridadSocial = table.Column<long>(nullable: false),
                    DondeViveId = table.Column<int>(nullable: false),
                    TermometroId = table.Column<int>(nullable: false),
                    Temperatura_Media = table.Column<decimal>(nullable: false),
                    MiMedicoCabeceraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pacientes_AbpUsers_DatosPersonalesId",
                        column: x => x.DatosPersonalesId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pacientes_direcciones_DondeViveId",
                        column: x => x.DondeViveId,
                        principalTable: "direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pacientes_medicos_MiMedicoCabeceraId",
                        column: x => x.MiMedicoCabeceraId,
                        principalTable: "medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_pacientes_termometros_TermometroId",
                        column: x => x.TermometroId,
                        principalTable: "termometros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    FechaHora = table.Column<DateTime>(nullable: false),
                    DireccionId = table.Column<int>(nullable: false),
                    Consulta = table.Column<string>(nullable: true),
                    Servicio_Especialidad = table.Column<string>(nullable: true),
                    Centro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_citas_direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadPaciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EnfermedadId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnfermedadPaciente_enfermedades_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "enfermedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfermedadPaciente_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteResponsable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    ResponsableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteResponsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteResponsable_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteResponsable_responsables_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "responsables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "prescripciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MedicamentoId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    Dosis = table.Column<decimal>(nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(nullable: false),
                    Fecha_Final = table.Column<DateTime>(nullable: false),
                    Como_Tomar = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescripciones_medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescripciones_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "temperaturaPacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    Temperatura = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temperaturaPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_temperaturaPacientes_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recordatorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PrescripcionId = table.Column<int>(nullable: false),
                    Texto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recordatorios_prescripciones_PrescripcionId",
                        column: x => x.PrescripcionId,
                        principalTable: "prescripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_citas_DireccionId",
                table: "citas",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_citas_MedicoId",
                table: "citas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_citas_PacienteId",
                table: "citas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadPaciente_EnfermedadId",
                table: "EnfermedadPaciente",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadPaciente_PacienteId",
                table: "EnfermedadPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_mensajes_PersonaDestinoId",
                table: "mensajes",
                column: "PersonaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_mensajes_PersonaOrigenId",
                table: "mensajes",
                column: "PersonaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteResponsable_PacienteId",
                table: "PacienteResponsable",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteResponsable_ResponsableId",
                table: "PacienteResponsable",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_DatosPersonalesId",
                table: "pacientes",
                column: "DatosPersonalesId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_DondeViveId",
                table: "pacientes",
                column: "DondeViveId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_MiMedicoCabeceraId",
                table: "pacientes",
                column: "MiMedicoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_TermometroId",
                table: "pacientes",
                column: "TermometroId");

            migrationBuilder.CreateIndex(
                name: "IX_prescripciones_MedicamentoId",
                table: "prescripciones",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_prescripciones_PacienteId",
                table: "prescripciones",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_recordatorios_PrescripcionId",
                table: "recordatorios",
                column: "PrescripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_responsables_DatosPersonalesId",
                table: "responsables",
                column: "DatosPersonalesId");

            migrationBuilder.CreateIndex(
                name: "IX_temperaturaPacientes_PacienteId",
                table: "temperaturaPacientes",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "EnfermedadPaciente");

            migrationBuilder.DropTable(
                name: "mensajes");

            migrationBuilder.DropTable(
                name: "PacienteResponsable");

            migrationBuilder.DropTable(
                name: "recordatorios");

            migrationBuilder.DropTable(
                name: "temperaturaPacientes");

            migrationBuilder.DropTable(
                name: "enfermedades");

            migrationBuilder.DropTable(
                name: "responsables");

            migrationBuilder.DropTable(
                name: "prescripciones");

            migrationBuilder.DropTable(
                name: "medicamentos");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "direcciones");

            migrationBuilder.DropTable(
                name: "termometros");
        }
    }
}
