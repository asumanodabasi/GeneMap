using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneMap.BLL.Migrations
{
    /// <inheritdoc />
    public partial class newpatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IllnessName",
                table: "Patients",
                newName: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "IllnessId",
                table: "PatientRelatives",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IllnessId",
                table: "PatientRelatives");

            migrationBuilder.RenameColumn(
                name: "Complaints",
                table: "Patients",
                newName: "IllnessName");
        }
    }
}
