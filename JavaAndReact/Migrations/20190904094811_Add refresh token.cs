using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaAndReact.Migrations
{
    public partial class Addrefreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "tblClientOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Token = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRefreshTokens_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRefreshTokens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "tblClientOrders");
        }
    }
}
