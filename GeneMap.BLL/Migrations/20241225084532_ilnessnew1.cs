using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class ilnessnew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IlnessPatient");

            migrationBuilder.CreateTable(
                name: "PatientIlnesses",
                columns: table => new
                {
                    IlnessId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientIlnesses", x => new { x.PatientId, x.IlnessId });
                    table.ForeignKey(
                        name: "FK_PatientIlnesses_Ilnesses_IlnessId",
                        column: x => x.IlnessId,
                        principalTable: "Ilnesses",
                        principalColumn: "IlnessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientIlnesses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientIlnesses_IlnessId",
                table: "PatientIlnesses",
                column: "IlnessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientIlnesses");

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
    }
}
