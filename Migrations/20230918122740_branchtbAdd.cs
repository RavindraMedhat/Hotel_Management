using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management.Migrations
{
    public partial class branchtbAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelBranchTB",
                columns: table => new
                {
                    Branch_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_ID = table.Column<int>(nullable: false),
                    Branch_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Branch_Description = table.Column<string>(maxLength: 300, nullable: false),
                    Branch_Images = table.Column<string>(nullable: false),
                    Branch_map_coordinate = table.Column<string>(nullable: false),
                    Branch_Address = table.Column<string>(maxLength: 50, nullable: false),
                    Branch_Contact_No = table.Column<string>(nullable: false),
                    Branch_Email_Adderss = table.Column<string>(nullable: false),
                    Branch_Contect_Person = table.Column<string>(maxLength: 50, nullable: false),
                    Active_Flag = table.Column<bool>(nullable: false),
                    Delete_Flag = table.Column<bool>(nullable: false),
                    Priority = table.Column<float>(nullable: false),
                    HotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranchTB", x => x.Branch_ID);
                    table.ForeignKey(
                        name: "FK_HotelBranchTB_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBranchTB_HotelId",
                table: "HotelBranchTB",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelBranchTB");
        }
    }
}
