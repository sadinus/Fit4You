using Microsoft.EntityFrameworkCore.Migrations;

namespace Fit4You.Core.Migrations
{
    public partial class PrzeniesieniepolaIsSubscribedztabeliUserdotabeliUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "UserData",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "UserData");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "User",
                nullable: false,
                defaultValue: false);
        }
    }
}
