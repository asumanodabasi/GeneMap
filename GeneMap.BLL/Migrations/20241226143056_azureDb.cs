using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class azureDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
    }
}
