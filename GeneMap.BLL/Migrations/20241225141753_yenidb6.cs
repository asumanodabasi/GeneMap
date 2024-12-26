using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class yenidb6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IlnessPatient",
                columns: table => new
                {
                    IlnessesIlnessId = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlnessPatient", x => new { x.IlnessesIlnessId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_IlnessPatient_Ilnesses_IlnessesIlnessId",
                        column: x => x.IlnessesIlnessId,
                        principalTable: "Ilnesses",
                        principalColumn: "IlnessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IlnessPatient_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IlnessPatient_PatientsPatientId",
                table: "IlnessPatient",
                column: "PatientsPatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IlnessPatient");
        }
    }
}
