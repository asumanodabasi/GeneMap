using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class ılnesadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PatientRelatives_IllnessId",
                table: "PatientRelatives",
                column: "IllnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRelatives_Ilnesses_IllnessId",
                table: "PatientRelatives",
                column: "IllnessId",
                principalTable: "Ilnesses",
                principalColumn: "IlnessId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientRelatives_Ilnesses_IllnessId",
                table: "PatientRelatives");

            migrationBuilder.DropIndex(
                name: "IX_PatientRelatives_IllnessId",
                table: "PatientRelatives");
        }
    }
}
