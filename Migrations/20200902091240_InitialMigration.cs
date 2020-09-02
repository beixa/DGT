using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DGT.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    Dni = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Puntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Infracciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false),
                    DescuentoPuntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infracciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Matricula = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    InfraccionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Infracciones_InfraccionId",
                        column: x => x.InfraccionId,
                        principalTable: "Infracciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConductorVehiculos",
                columns: table => new
                {
                    Dni = table.Column<string>(nullable: false),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConductorVehiculos", x => new { x.Dni, x.Matricula });
                    table.ForeignKey(
                        name: "FK_ConductorVehiculos_Conductores_Dni",
                        column: x => x.Dni,
                        principalTable: "Conductores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConductorVehiculos_Vehiculos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sanciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ConductorDni = table.Column<string>(nullable: true),
                    VehiculoMatricula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanciones_Conductores_ConductorDni",
                        column: x => x.ConductorDni,
                        principalTable: "Conductores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sanciones_Vehiculos_VehiculoMatricula",
                        column: x => x.VehiculoMatricula,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConductorVehiculos_Matricula",
                table: "ConductorVehiculos",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Sanciones_ConductorDni",
                table: "Sanciones",
                column: "ConductorDni");

            migrationBuilder.CreateIndex(
                name: "IX_Sanciones_VehiculoMatricula",
                table: "Sanciones",
                column: "VehiculoMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_InfraccionId",
                table: "Vehiculos",
                column: "InfraccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConductorVehiculos");

            migrationBuilder.DropTable(
                name: "Sanciones");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Infracciones");
        }
    }
}
