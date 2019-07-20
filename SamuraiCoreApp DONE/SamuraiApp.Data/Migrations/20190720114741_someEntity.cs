using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class someEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KillStreak",
                table: "SamuraiBattle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SomeEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SomeProp1 = table.Column<string>(nullable: true),
                    SomeProp2 = table.Column<int>(nullable: false),
                    SomeProp3 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SomeEntities");

            migrationBuilder.DropColumn(
                name: "KillStreak",
                table: "SamuraiBattle");
        }
    }
}
