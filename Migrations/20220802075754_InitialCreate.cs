using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: " dbo");

            migrationBuilder.CreateTable(
                name: "FavoriteCities",
                schema: " dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityKey = table.Column<int>(type: "int", nullable: false),
                    cityName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCities",
                schema: " dbo");
        }
    }
}
