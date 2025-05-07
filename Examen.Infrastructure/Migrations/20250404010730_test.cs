using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analse",
                columns: table => new
                {
                    AnalyseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DureeResultat = table.Column<int>(type: "int", nullable: false),
                    PrixResultat = table.Column<double>(type: "float", nullable: false),
                    TypeAnalyse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeurAnalyse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeurMaxNormale = table.Column<float>(type: "real", nullable: false),
                    ValeurMinNormale = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analse", x => x.AnalyseId);
                });

            migrationBuilder.CreateTable(
                name: "Laboratoires",
                columns: table => new
                {
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseLabo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratoires", x => x.LaboratoireId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    CodePatient = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.CodePatient);
                });

            migrationBuilder.CreateTable(
                name: "Infirmiers",
                columns: table => new
                {
                    InfirmierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<int>(type: "int", nullable: false),
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infirmiers", x => x.InfirmierId);
                    table.ForeignKey(
                        name: "FK_Infirmiers_Laboratoires_LaboratoireId",
                        column: x => x.LaboratoireId,
                        principalTable: "Laboratoires",
                        principalColumn: "LaboratoireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilans",
                columns: table => new
                {
                    DatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    CodePatient = table.Column<int>(type: "int", nullable: false),
                    EmailMedecin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilans", x => new { x.CodePatient, x.CodeInfirmier, x.DatePrelevement });
                    table.ForeignKey(
                        name: "FK_Bilans_Infirmiers_CodeInfirmier",
                        column: x => x.CodeInfirmier,
                        principalTable: "Infirmiers",
                        principalColumn: "InfirmierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilans_Patients_CodePatient",
                        column: x => x.CodePatient,
                        principalTable: "Patients",
                        principalColumn: "CodePatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalyseBilan",
                columns: table => new
                {
                    AnalysesAnalyseId = table.Column<int>(type: "int", nullable: false),
                    BilansCodePatient = table.Column<int>(type: "int", nullable: false),
                    BilansCodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    BilansDatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyseBilan", x => new { x.AnalysesAnalyseId, x.BilansCodePatient, x.BilansCodeInfirmier, x.BilansDatePrelevement });
                    table.ForeignKey(
                        name: "FK_AnalyseBilan_Analse_AnalysesAnalyseId",
                        column: x => x.AnalysesAnalyseId,
                        principalTable: "Analse",
                        principalColumn: "AnalyseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalyseBilan_Bilans_BilansCodePatient_BilansCodeInfirmier_BilansDatePrelevement",
                        columns: x => new { x.BilansCodePatient, x.BilansCodeInfirmier, x.BilansDatePrelevement },
                        principalTable: "Bilans",
                        principalColumns: new[] { "CodePatient", "CodeInfirmier", "DatePrelevement" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyseBilan_BilansCodePatient_BilansCodeInfirmier_BilansDatePrelevement",
                table: "AnalyseBilan",
                columns: new[] { "BilansCodePatient", "BilansCodeInfirmier", "BilansDatePrelevement" });

            migrationBuilder.CreateIndex(
                name: "IX_Bilans_CodeInfirmier",
                table: "Bilans",
                column: "CodeInfirmier");

            migrationBuilder.CreateIndex(
                name: "IX_Infirmiers_LaboratoireId",
                table: "Infirmiers",
                column: "LaboratoireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyseBilan");

            migrationBuilder.DropTable(
                name: "Analse");

            migrationBuilder.DropTable(
                name: "Bilans");

            migrationBuilder.DropTable(
                name: "Infirmiers");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Laboratoires");
        }
    }
}
