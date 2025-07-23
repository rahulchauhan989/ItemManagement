using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class StatusUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_created_by",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_modified_by",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_user_id",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_created_by",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_modified_by",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_user_id",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "status",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "status",
                table: "ItemRequests");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ReturnRequests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ReturnRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ReturnRequests",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "return_request_number",
                table: "ReturnRequests",
                newName: "ReturnRequestNumber");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "ReturnRequests",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ReturnRequests",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ReturnRequests",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ReturnRequests",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_user_id",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_modified_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_created_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "ItemRequests",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ItemRequests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ItemRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ItemRequests",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "request_number",
                table: "ItemRequests",
                newName: "RequestNumber");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "ItemRequests",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ItemRequests",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ItemRequests",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ItemRequests",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_user_id",
                table: "ItemRequests",
                newName: "IX_ItemRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_modified_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_created_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_CreatedBy");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ReturnRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ItemRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_StatusId",
                table: "ReturnRequests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequests_StatusId",
                table: "ItemRequests",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Statuses_StatusId",
                table: "ItemRequests",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_CreatedBy",
                table: "ItemRequests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_ModifiedBy",
                table: "ItemRequests",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_UserId",
                table: "ItemRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Statuses_StatusId",
                table: "ReturnRequests",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_CreatedBy",
                table: "ReturnRequests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_ModifiedBy",
                table: "ReturnRequests",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_UserId",
                table: "ReturnRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Statuses_StatusId",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_CreatedBy",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_ModifiedBy",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_UserId",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Statuses_StatusId",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_CreatedBy",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_ModifiedBy",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_UserId",
                table: "ReturnRequests");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_ReturnRequests_StatusId",
                table: "ReturnRequests");

            migrationBuilder.DropIndex(
                name: "IX_ItemRequests_StatusId",
                table: "ItemRequests");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemRequests");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ItemRequests");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReturnRequests",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ReturnRequests",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ReturnRequests",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReturnRequestNumber",
                table: "ReturnRequests",
                newName: "return_request_number");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ReturnRequests",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ReturnRequests",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ReturnRequests",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ReturnRequests",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_UserId",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_ModifiedBy",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_CreatedBy",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_created_by");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "ItemRequests",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemRequests",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ItemRequests",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ItemRequests",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "ItemRequests",
                newName: "request_number");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ItemRequests",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ItemRequests",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ItemRequests",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ItemRequests",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_UserId",
                table: "ItemRequests",
                newName: "IX_ItemRequests_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_ModifiedBy",
                table: "ItemRequests",
                newName: "IX_ItemRequests_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_CreatedBy",
                table: "ItemRequests",
                newName: "IX_ItemRequests_created_by");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "ReturnRequests",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "ItemRequests",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_created_by",
                table: "ItemRequests",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_modified_by",
                table: "ItemRequests",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_user_id",
                table: "ItemRequests",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_created_by",
                table: "ReturnRequests",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_modified_by",
                table: "ReturnRequests",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_user_id",
                table: "ReturnRequests",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
