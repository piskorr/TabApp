using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class ModelsNew123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_SenderID",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "SenderID",
                table: "Message",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddresseeID",
                table: "Message",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Message_AddresseeID",
                table: "Message",
                column: "AddresseeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_AddresseeID",
                table: "Message",
                column: "AddresseeID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_SenderID",
                table: "Message",
                column: "SenderID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_AddresseeID",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_SenderID",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_AddresseeID",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "AddresseeID",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "SenderID",
                table: "Message",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_SenderID",
                table: "Message",
                column: "SenderID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
