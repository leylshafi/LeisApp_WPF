using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class removeretweets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Replies_ReTweetId",
                table: "Tweets");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Tweets_ReTweetId",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "ReTweetId",
                table: "Tweets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReTweetId",
                table: "Tweets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_ReTweetId",
                table: "Tweets",
                column: "ReTweetId",
                unique: true,
                filter: "[ReTweetId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Replies_ReTweetId",
                table: "Tweets",
                column: "ReTweetId",
                principalTable: "Replies",
                principalColumn: "Id");
        }
    }
}
