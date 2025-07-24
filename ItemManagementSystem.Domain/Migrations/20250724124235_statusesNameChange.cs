using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class statusesNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_request_Statuses_status_id",
                table: "item_request");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_Statuses_status_id",
                table: "return_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "statuses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "statuses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "statuses",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_statuses",
                table: "statuses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_statuses_status_id",
                table: "item_request",
                column: "status_id",
                principalTable: "statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_statuses_status_id",
                table: "return_request",
                column: "status_id",
                principalTable: "statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_request_statuses_status_id",
                table: "item_request");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_statuses_status_id",
                table: "return_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_statuses",
                table: "statuses");

            migrationBuilder.RenameTable(
                name: "statuses",
                newName: "Statuses");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Statuses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Statuses",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_Statuses_status_id",
                table: "item_request",
                column: "status_id",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_Statuses_status_id",
                table: "return_request",
                column: "status_id",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
