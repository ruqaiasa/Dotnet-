using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infirmiers_Laboratoires_LaboratoireId",
                table: "Infirmiers");

            migrationBuilder.RenameColumn(
                name: "LaboratoireId",
                table: "Infirmiers",
                newName: "CodeLaboratoire");

            migrationBuilder.RenameIndex(
                name: "IX_Infirmiers_LaboratoireId",
                table: "Infirmiers",
                newName: "IX_Infirmiers_CodeLaboratoire");

            migrationBuilder.AddForeignKey(
                name: "FK_Infirmiers_Laboratoires_CodeLaboratoire",
                table: "Infirmiers",
                column: "CodeLaboratoire",
                principalTable: "Laboratoires",
                principalColumn: "LaboratoireId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infirmiers_Laboratoires_CodeLaboratoire",
                table: "Infirmiers");

            migrationBuilder.RenameColumn(
                name: "CodeLaboratoire",
                table: "Infirmiers",
                newName: "LaboratoireId");

            migrationBuilder.RenameIndex(
                name: "IX_Infirmiers_CodeLaboratoire",
                table: "Infirmiers",
                newName: "IX_Infirmiers_LaboratoireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Infirmiers_Laboratoires_LaboratoireId",
                table: "Infirmiers",
                column: "LaboratoireId",
                principalTable: "Laboratoires",
                principalColumn: "LaboratoireId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
