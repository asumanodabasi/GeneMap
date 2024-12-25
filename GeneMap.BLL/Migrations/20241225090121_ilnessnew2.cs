using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class ilnessnew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Ilnesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ilnesses_PatientId",
                table: "Ilnesses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilnesses_Patients_PatientId",
                table: "Ilnesses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilnesses_Patients_PatientId",
                table: "Ilnesses");

            migrationBuilder.DropIndex(
                name: "IX_Ilnesses_PatientId",
                table: "Ilnesses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Ilnesses");
        }
    }
}
