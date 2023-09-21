using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management.Migrations
{
    public partial class fm : Migration
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
                    Branch_map_coordinate = table.Column<string>(nullable: false),
                    Branch_Address = table.Column<string>(maxLength: 50, nullable: false),
                    Branch_Contact_No = table.Column<string>(nullable: false),
                    Branch_Email_Adderss = table.Column<string>(nullable: false),
                    Branch_Contect_Person = table.Column<string>(maxLength: 50, nullable: false),
                    Active_Flag = table.Column<bool>(nullable: false),
                    Delete_Flag = table.Column<bool>(nullable: false),
                    Priority = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranchTB", x => x.Branch_ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Hotel_Description = table.Column<string>(maxLength: 300, nullable: false),
                    Hotel_map_coordinate = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Contact_No = table.Column<string>(nullable: false),
                    Email_Adderss = table.Column<string>(nullable: false),
                    Contect_Person = table.Column<string>(maxLength: 50, nullable: false),
                    Standard_check_In_Time = table.Column<string>(nullable: false),
                    Standard_check_out_Time = table.Column<string>(nullable: false),
                    Active_Flag = table.Column<bool>(nullable: false),
                    Delete_Flag = table.Column<bool>(nullable: false),
                    Priority = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelBranchTB");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
