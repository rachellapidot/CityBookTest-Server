using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.App.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cityName",
                schema: " dbo",
                table: "FavoriteCities",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "cityKey",
                schema: " dbo",
                table: "FavoriteCities",
                newName: "CityKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                schema: " dbo",
                table: "FavoriteCities",
                newName: "cityName");

            migrationBuilder.RenameColumn(
                name: "CityKey",
                schema: " dbo",
                table: "FavoriteCities",
                newName: "cityKey");
        }
    }
}
