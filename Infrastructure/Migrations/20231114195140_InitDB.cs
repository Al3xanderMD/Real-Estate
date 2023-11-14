using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BasePosts_UserId",
                table: "BasePosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePosts_Clients_UserId",
                table: "BasePosts",
                column: "UserId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePosts_Clients_UserId",
                table: "BasePosts");

            migrationBuilder.DropIndex(
                name: "IX_BasePosts_UserId",
                table: "BasePosts");
        }
    }
}
