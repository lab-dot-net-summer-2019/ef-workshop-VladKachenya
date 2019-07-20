using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class someEntityRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.RenameTable(
                name: "SamuraiBattle",
                newName: "SamuraiBattles");

            migrationBuilder.RenameIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattles",
                newName: "IX_SamuraiBattles_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattles",
                table: "SamuraiBattles",
                columns: new[] { "BattleId", "SamuraiId" });

            migrationBuilder.CreateTable(
                name: "SamuraiSomeEntity",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(nullable: false),
                    SomeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiSomeEntity", x => new { x.SomeEntityId, x.SamuraiId });
                    table.ForeignKey(
                        name: "FK_SamuraiSomeEntity_SomeEntities_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "SomeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiSomeEntity_Samurais_SomeEntityId",
                        column: x => x.SomeEntityId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiSomeEntity_SamuraiId",
                table: "SamuraiSomeEntity",
                column: "SamuraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Samurais_SamuraiId",
                table: "SamuraiBattles",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleId",
                table: "SamuraiBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Samurais_SamuraiId",
                table: "SamuraiBattles");

            migrationBuilder.DropTable(
                name: "SamuraiSomeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattles",
                table: "SamuraiBattles");

            migrationBuilder.RenameTable(
                name: "SamuraiBattles",
                newName: "SamuraiBattle");

            migrationBuilder.RenameIndex(
                name: "IX_SamuraiBattles_SamuraiId",
                table: "SamuraiBattle",
                newName: "IX_SamuraiBattle_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "BattleId", "SamuraiId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
