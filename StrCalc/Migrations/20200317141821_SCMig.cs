using Microsoft.EntityFrameworkCore.Migrations;

namespace StrCalc.Migrations
{
    public partial class SCMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(nullable: false),
                    Pw = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "MPfmc",
                columns: table => new
                {
                    No = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    BP = table.Column<float>(nullable: false),
                    DL = table.Column<float>(nullable: false),
                    SQT = table.Column<float>(nullable: false),
                    Big3Weight = table.Column<string>(nullable: true),
                    WP = table.Column<float>(nullable: false),
                    WR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPfmc", x => x.No);
                    table.ForeignKey(
                        name: "FK_MPfmc_Members_No",
                        column: x => x.No,
                        principalTable: "Members",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MPfmc");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
