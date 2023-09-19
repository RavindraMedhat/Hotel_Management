using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management.Migrations
{
    public partial class tbWithoutImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hotel_Images",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Branch_Images",
                table: "HotelBranchTB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hotel_Images",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Branch_Images",
                table: "HotelBranchTB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
