using Microsoft.EntityFrameworkCore.Migrations;

namespace Fit4You.Core.Migrations
{
    public partial class ZmianatypuinazwypolaGenderwtabeliUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserData");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "UserData",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "UserData",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<bool>(
                name: "isMale",
                table: "UserData",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMale",
                table: "UserData");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "UserData",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "UserData",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ActivityType",
                table: "UserData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "UserData",
                nullable: false,
                defaultValue: 0);
        }
    }
}
