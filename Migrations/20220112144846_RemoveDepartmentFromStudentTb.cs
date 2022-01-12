using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System.Migrations
{
    public partial class RemoveDepartmentFromStudentTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_Department",
                table: "students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Student_Department",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
