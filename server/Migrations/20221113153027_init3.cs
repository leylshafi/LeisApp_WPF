using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Replies_ReTweetId",
                table: "Tweets");

            migrationBuilder.DropIndex(
                name: "IX_Tweets_ReTweetId",
                table: "Tweets");

            migrationBuilder.AlterColumn<int>(
                name: "ReTweetId",
                table: "Tweets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Replies_ReTweetId",
                table: "Tweets");

            migrationBuilder.DropIndex(
                name: "IX_Tweets_ReTweetId",
                table: "Tweets");

            migrationBuilder.AlterColumn<int>(
                name: "ReTweetId",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_ReTweetId",
                table: "Tweets",
                column: "ReTweetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Replies_ReTweetId",
                table: "Tweets",
                column: "ReTweetId",
                principalTable: "Replies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
