using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Data.Migrations
{
    public partial class MeetAMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetAMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    PictureURL = table.Column<string>(nullable: true),
                    Para1 = table.Column<string>(nullable: true),
                    Para2 = table.Column<string>(nullable: true),
                    Para3 = table.Column<string>(nullable: true),
                    Para4 = table.Column<string>(nullable: true),
                    Para5 = table.Column<string>(nullable: true),
                    Para6 = table.Column<string>(nullable: true),
                    Para7 = table.Column<string>(nullable: true),
                    Para8 = table.Column<string>(nullable: true),
                    Para9 = table.Column<string>(nullable: true),
                    Para10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetAMembers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "MeetAMembers");
        }
    }
}
