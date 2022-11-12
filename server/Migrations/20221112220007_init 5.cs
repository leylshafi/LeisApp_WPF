using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Users_UserId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_Users_UserId",
                table: "Tweet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tweet",
                table: "Tweet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.RenameTable(
                name: "Tweet",
                newName: "Tweets");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "Replies");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_UserId",
                table: "Tweets",
                newName: "IX_Tweets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_UserId",
                table: "Replies",
                newName: "IX_Replies_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Users_UserId",
                table: "Replies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Users_UserId",
                table: "Tweets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Users_UserId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Users_UserId",
                table: "Tweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.RenameTable(
                name: "Tweets",
                newName: "Tweet");

            migrationBuilder.RenameTable(
                name: "Replies",
                newName: "Reply");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_UserId",
                table: "Tweet",
                newName: "IX_Tweet_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_UserId",
                table: "Reply",
                newName: "IX_Reply_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tweet",
                table: "Tweet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Users_UserId",
                table: "Reply",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_Users_UserId",
                table: "Tweet",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
