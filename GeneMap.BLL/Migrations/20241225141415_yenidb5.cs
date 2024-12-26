using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class yenidb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientRelatives_Ilnesses_IllnessId",
                table: "PatientRelatives");

            migrationBuilder.DropTable(
                name: "IlnessPatient");

            migrationBuilder.DropIndex(
                name: "IX_PatientRelatives_IllnessId",
                table: "PatientRelatives");

            migrationBuilder.AddColumn<int>(
                name: "PatientRelativeId",
                table: "Ilnesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ilnesses_PatientRelativeId",
                table: "Ilnesses",
                column: "PatientRelativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilnesses_PatientRelatives_PatientRelativeId",
                table: "Ilnesses",
                column: "PatientRelativeId",
                principalTable: "PatientRelatives",
                principalColumn: "PatientRelativeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilnesses_PatientRelatives_PatientRelativeId",
                table: "Ilnesses");

            migrationBuilder.DropIndex(
                name: "IX_Ilnesses_PatientRelativeId",
                table: "Ilnesses");

            migrationBuilder.DropColumn(
                name: "PatientRelativeId",
                table: "Ilnesses");

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
                name: "IX_PatientRelatives_IllnessId",
                table: "PatientRelatives",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_IlnessPatient_PatientsPatientId",
                table: "IlnessPatient",
                column: "PatientsPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRelatives_Ilnesses_IllnessId",
                table: "PatientRelatives",
                column: "IllnessId",
                principalTable: "Ilnesses",
                principalColumn: "IlnessId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
