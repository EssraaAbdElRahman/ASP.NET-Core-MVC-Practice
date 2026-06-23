using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCApplication.Migrations
{
    /// <inheritdoc />
    public partial class addHourColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Houre",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Houre",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Houre",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Houre",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name_DepartmentId",
                table: "Courses",
                columns: new[] { "Name", "DepartmentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_Name_DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Houre",
                table: "Courses");
        }
    }
}
