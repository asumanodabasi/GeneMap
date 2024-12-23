using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class PatientRelative : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientPatientRelatives",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientRelativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPatientRelatives", x => new { x.PatientId, x.PatientRelativeId });
                    table.ForeignKey(
                        name: "FK_PatientPatientRelatives_PatientRelatives_PatientRelativeId",
                        column: x => x.PatientRelativeId,
                        principalTable: "PatientRelatives",
                        principalColumn: "PatientRelativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientPatientRelatives_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientPatientRelatives_PatientRelativeId",
                table: "PatientPatientRelatives",
                column: "PatientRelativeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientPatientRelatives");
        }
    }
}
