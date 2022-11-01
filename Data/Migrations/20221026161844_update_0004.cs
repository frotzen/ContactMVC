using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMVC.Data.Migrations
{
    public partial class update_0004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_AppUserId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AppUserId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Contacts",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AppUserId",
                table: "Contacts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_AppUserId",
                table: "Contacts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_AppUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AppUserId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Contacts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AppUserId1",
                table: "Contacts",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_AppUserId1",
                table: "Contacts",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
