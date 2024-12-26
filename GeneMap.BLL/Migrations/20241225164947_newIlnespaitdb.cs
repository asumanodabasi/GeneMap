using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class newIlnespaitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IlnessPatientRelative");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IlnessPatientRelative",
                columns: table => new
                {
                    IlnessId = table.Column<int>(type: "int", nullable: false),
                    PatientRelativesPatientRelativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlnessPatientRelative", x => new { x.IlnessId, x.PatientRelativesPatientRelativeId });
                    table.ForeignKey(
                        name: "FK_IlnessPatientRelative_Ilnesses_IlnessId",
                        column: x => x.IlnessId,
                        principalTable: "Ilnesses",
                        principalColumn: "IlnessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IlnessPatientRelative_PatientRelatives_PatientRelativesPatientRelativeId",
                        column: x => x.PatientRelativesPatientRelativeId,
                        principalTable: "PatientRelatives",
                        principalColumn: "PatientRelativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IlnessPatientRelative_PatientRelativesPatientRelativeId",
                table: "IlnessPatientRelative",
                column: "PatientRelativesPatientRelativeId");
        }
    }
}
