using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddIcollectionOfItm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemRequestId",
                table: "ItemRequestDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequestDetails_ItemRequestId",
                table: "ItemRequestDetails",
                column: "ItemRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails",
                column: "ItemRequestId",
                principalTable: "ItemRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_ItemRequestDetails_ItemRequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropColumn(
                name: "ItemRequestId",
                table: "ItemRequestDetails");
        }
    }
}
