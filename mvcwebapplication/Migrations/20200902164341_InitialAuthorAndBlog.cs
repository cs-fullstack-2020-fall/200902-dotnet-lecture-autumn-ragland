using Microsoft.EntityFrameworkCore.Migrations;

namespace mvcwebapplication.Migrations
{
    public partial class InitialAuthorAndBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fName = table.Column<string>(nullable: true),
                    lName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    text = table.Column<string>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    Authorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Authors_Authorid",
                        column: x => x.Authorid,
                        principalTable: "Authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Authorid",
                table: "BlogPosts",
                column: "Authorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
