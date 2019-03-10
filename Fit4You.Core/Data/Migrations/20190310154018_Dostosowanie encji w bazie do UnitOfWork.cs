using Microsoft.EntityFrameworkCore.Migrations;

namespace Fit4You.Core.Migrations
{
    public partial class DostosowanieencjiwbaziedoUnitOfWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserDataID",
                table: "UserData",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "User",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserData",
                newName: "UserDataID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserID");
        }
    }
}
