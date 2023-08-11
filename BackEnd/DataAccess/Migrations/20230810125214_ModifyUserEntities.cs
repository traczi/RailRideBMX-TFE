using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ModifyUserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Firstname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Users",
                newName: "Name");
        }
    }
}
