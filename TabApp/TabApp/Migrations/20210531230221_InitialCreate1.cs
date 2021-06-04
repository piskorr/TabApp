using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonWorker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonID = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonWorker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonWorker_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonWorker_PersonWorker_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "PersonWorker",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorker_PersonID",
                table: "PersonWorker",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorker_WorkerID",
                table: "PersonWorker",
                column: "WorkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonWorker");
        }
    }
}
