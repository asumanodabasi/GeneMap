using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class relatvies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientPatientRelative");

            migrationBuilder.AddColumn<string>(
                name: "Relation",
                table: "PatientPatientRelatives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relation",
                table: "PatientPatientRelatives");

            migrationBuilder.CreateTable(
                name: "PatientPatientRelative",
                columns: table => new
                {
                    PatientRelativesPatientRelativeId = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPatientRelative", x => new { x.PatientRelativesPatientRelativeId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_PatientPatientRelative_PatientRelatives_PatientRelativesPatientRelativeId",
                        column: x => x.PatientRelativesPatientRelativeId,
                        principalTable: "PatientRelatives",
                        principalColumn: "PatientRelativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientPatientRelative_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientPatientRelative_PatientsPatientId",
                table: "PatientPatientRelative",
                column: "PatientsPatientId");
        }
    }
}
