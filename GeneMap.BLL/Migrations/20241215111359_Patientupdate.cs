using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class Patientupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosiss_Patients_IlnessId",
                table: "Diagnosiss");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosiss_PatientId",
                table: "Diagnosiss",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosiss_Patients_PatientId",
                table: "Diagnosiss",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosiss_Patients_PatientId",
                table: "Diagnosiss");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosiss_PatientId",
                table: "Diagnosiss");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosiss_Patients_IlnessId",
                table: "Diagnosiss",
                column: "IlnessId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
