using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "LoginDTOs",
                newName: "Username");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "LoginDTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableId",
                table: "LoginDTOs");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "LoginDTOs",
                newName: "UserName");
        }
    }
}
