using Microsoft.EntityFrameworkCore.Migrations;

namespace Fit4You.Core.Migrations
{
    public partial class UsunieciekolumnyusernameztabeliUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "User",
                nullable: true);
        }
    }
}
