using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceReact.Migrations
{
    public partial class AjoutChampImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Produits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Produits");
        }
    }
}
