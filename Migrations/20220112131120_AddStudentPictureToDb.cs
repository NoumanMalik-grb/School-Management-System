using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System.Migrations
{
    public partial class AddStudentPictureToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Student_Picture",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_Picture",
                table: "students");
        }
    }
}
