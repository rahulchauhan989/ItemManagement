using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RenameFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_RequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_ItemRequestDetails_RequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "ItemRequestDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ItemRequestId",
                table: "ItemRequestDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemRequestId1",
                table: "ItemRequestDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemRequestDetailId",
                table: "ItemModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequestDetails_ItemRequestId1",
                table: "ItemRequestDetails",
                column: "ItemRequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModels_ItemRequestDetailId",
                table: "ItemModels",
                column: "ItemRequestDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_ItemRequestDetails_ItemRequestDetailId",
                table: "ItemModels",
                column: "ItemRequestDetailId",
                principalTable: "ItemRequestDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails",
                column: "ItemRequestId",
                principalTable: "ItemRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId1",
                table: "ItemRequestDetails",
                column: "ItemRequestId1",
                principalTable: "ItemRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_ItemRequestDetails_ItemRequestDetailId",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId1",
                table: "ItemRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_ItemRequestDetails_ItemRequestId1",
                table: "ItemRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_ItemModels_ItemRequestDetailId",
                table: "ItemModels");

            migrationBuilder.DropColumn(
                name: "ItemRequestId1",
                table: "ItemRequestDetails");

            migrationBuilder.DropColumn(
                name: "ItemRequestDetailId",
                table: "ItemModels");

            migrationBuilder.AlterColumn<int>(
                name: "ItemRequestId",
                table: "ItemRequestDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "ItemRequestDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequestDetails_RequestId",
                table: "ItemRequestDetails",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails",
                column: "ItemRequestId",
                principalTable: "ItemRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_RequestId",
                table: "ItemRequestDetails",
                column: "RequestId",
                principalTable: "ItemRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
