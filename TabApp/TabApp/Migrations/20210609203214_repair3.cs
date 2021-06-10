using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class repair3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Repair",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Repair",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
