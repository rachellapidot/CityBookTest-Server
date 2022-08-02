using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.App.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("dbo");

            migrationBuilder.CreateTable(

                name: "FavoriteCities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation(name: "SqlServer:Indetity", value: "1, 1"),
                    CityKey = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(name: "PK_Fvorite", columns: x => x.Id);
                }
            );
        } 

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCities",
                schema: "dbo"
            );
        }
    }
}
