using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class yenias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
