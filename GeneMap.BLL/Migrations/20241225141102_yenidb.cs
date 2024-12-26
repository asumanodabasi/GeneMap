using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class yenidb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilnesses_Ilnesses_IlnessId1",
                table: "Ilnesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilnesses_Patients_PatientId",
                table: "Ilnesses");

            migrationBuilder.DropIndex(
                name: "IX_Ilnesses_IlnessId1",
                table: "Ilnesses");

            migrationBuilder.DropIndex(
                name: "IX_Ilnesses_PatientId",
                table: "Ilnesses");

            migrationBuilder.DropColumn(
                name: "IlnessId1",
                table: "Ilnesses");

            migrationBuilder.DropColumn(
                name: "PatientId",
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
                name: "IX_IlnessPatient_PatientsPatientId",
                table: "IlnessPatient",
                column: "PatientsPatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IlnessPatient");

            migrationBuilder.AddColumn<int>(
                name: "IlnessId1",
                table: "Ilnesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Ilnesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ilnesses_IlnessId1",
                table: "Ilnesses",
                column: "IlnessId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ilnesses_PatientId",
                table: "Ilnesses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilnesses_Ilnesses_IlnessId1",
                table: "Ilnesses",
                column: "IlnessId1",
                principalTable: "Ilnesses",
                principalColumn: "IlnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilnesses_Patients_PatientId",
                table: "Ilnesses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }
    }
}
