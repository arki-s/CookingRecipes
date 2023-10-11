using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingRecipes.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commnet",
                table: "Review",
                newName: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Review",
                newName: "Commnet");
        }
    }
}
