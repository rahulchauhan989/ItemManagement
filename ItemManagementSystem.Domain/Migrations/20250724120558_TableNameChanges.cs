using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class TableNameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_ItemRequestDetails_ItemRequestDetailId",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_ItemTypes_ItemTypeId1",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_ItemTypes_item_type_id",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_Users_created_by",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_Users_modified_by",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemModels_item_model_id",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId1",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_item_request_id",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_Users_created_by",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_Users_modified_by",
                table: "ItemRequestDetails");

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
                name: "FK_ItemTypes_Users_created_by",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_Users_modified_by",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDetails_ItemModels_item_model_id",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDetails_PurchaseRequests_purchase_request_id",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDetails_Users_created_by",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_UserId",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_created_by",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_modified_by",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_ItemModels_item_model_id",
                table: "ReturnRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_ReturnRequests_return_request_id",
                table: "ReturnRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_Users_created_by",
                table: "ReturnRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_Users_modified_by",
                table: "ReturnRequestDetails");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedBy",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_ModifiedBy",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_role_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedBy",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifiedBy",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnRequests",
                table: "ReturnRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnRequestDetails",
                table: "ReturnRequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequestDetails",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRequests",
                table: "ItemRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRequestDetails",
                table: "ItemRequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModels",
                table: "ItemModels");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "ReturnRequests",
                newName: "return_request");

            migrationBuilder.RenameTable(
                name: "ReturnRequestDetails",
                newName: "return_request_detail");

            migrationBuilder.RenameTable(
                name: "PurchaseRequests",
                newName: "purchase_request");

            migrationBuilder.RenameTable(
                name: "PurchaseRequestDetails",
                newName: "purchase_request_detail");

            migrationBuilder.RenameTable(
                name: "ItemTypes",
                newName: "item_type");

            migrationBuilder.RenameTable(
                name: "ItemRequests",
                newName: "item_request");

            migrationBuilder.RenameTable(
                name: "ItemRequestDetails",
                newName: "item_request_detail");

            migrationBuilder.RenameTable(
                name: "ItemModels",
                newName: "item_model");

            migrationBuilder.RenameIndex(
                name: "IX_Users_role_id",
                table: "users",
                newName: "IX_users_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ModifiedBy",
                table: "users",
                newName: "IX_users_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CreatedBy",
                table: "users",
                newName: "IX_users_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_ModifiedBy",
                table: "roles",
                newName: "IX_roles_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_CreatedBy",
                table: "roles",
                newName: "IX_roles_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "return_request",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "return_request",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "return_request",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "return_request",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "return_request",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "return_request",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "return_request",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "return_request",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_UserId",
                table: "return_request",
                newName: "IX_return_request_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_StatusId",
                table: "return_request",
                newName: "IX_return_request_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_ModifiedBy",
                table: "return_request",
                newName: "IX_return_request_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_CreatedBy",
                table: "return_request",
                newName: "IX_return_request_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_return_request_id",
                table: "return_request_detail",
                newName: "IX_return_request_detail_return_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_modified_by",
                table: "return_request_detail",
                newName: "IX_return_request_detail_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_item_model_id",
                table: "return_request_detail",
                newName: "IX_return_request_detail_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_created_by",
                table: "return_request_detail",
                newName: "IX_return_request_detail_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_UserId",
                table: "purchase_request",
                newName: "IX_purchase_request_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_modified_by",
                table: "purchase_request",
                newName: "IX_purchase_request_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_created_by",
                table: "purchase_request",
                newName: "IX_purchase_request_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_purchase_request_id",
                table: "purchase_request_detail",
                newName: "IX_purchase_request_detail_purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_item_model_id",
                table: "purchase_request_detail",
                newName: "IX_purchase_request_detail_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_created_by",
                table: "purchase_request_detail",
                newName: "IX_purchase_request_detail_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypes_modified_by",
                table: "item_type",
                newName: "IX_item_type_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypes_created_by",
                table: "item_type",
                newName: "IX_item_type_created_by");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item_request",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "item_request",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "item_request",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "item_request",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "item_request",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "item_request",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "item_request",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "item_request",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_UserId",
                table: "item_request",
                newName: "IX_item_request_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_StatusId",
                table: "item_request",
                newName: "IX_item_request_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_ModifiedBy",
                table: "item_request",
                newName: "IX_item_request_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_CreatedBy",
                table: "item_request",
                newName: "IX_item_request_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_modified_by",
                table: "item_request_detail",
                newName: "IX_item_request_detail_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_ItemRequestId1",
                table: "item_request_detail",
                newName: "IX_item_request_detail_ItemRequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_item_request_id",
                table: "item_request_detail",
                newName: "IX_item_request_detail_item_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_item_model_id",
                table: "item_request_detail",
                newName: "IX_item_request_detail_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_created_by",
                table: "item_request_detail",
                newName: "IX_item_request_detail_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_modified_by",
                table: "item_model",
                newName: "IX_item_model_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_ItemTypeId1",
                table: "item_model",
                newName: "IX_item_model_ItemTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_ItemRequestDetailId",
                table: "item_model",
                newName: "IX_item_model_ItemRequestDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_item_type_id",
                table: "item_model",
                newName: "IX_item_model_item_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_created_by",
                table: "item_model",
                newName: "IX_item_model_created_by");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_return_request",
                table: "return_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_return_request_detail",
                table: "return_request_detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_request",
                table: "purchase_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_request_detail",
                table: "purchase_request_detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_type",
                table: "item_type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_request",
                table: "item_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_request_detail",
                table: "item_request_detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_model",
                table: "item_model",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_model_item_request_detail_ItemRequestDetailId",
                table: "item_model",
                column: "ItemRequestDetailId",
                principalTable: "item_request_detail",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_model_item_type_ItemTypeId1",
                table: "item_model",
                column: "ItemTypeId1",
                principalTable: "item_type",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_model_item_type_item_type_id",
                table: "item_model",
                column: "item_type_id",
                principalTable: "item_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_model_users_created_by",
                table: "item_model",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_model_users_modified_by",
                table: "item_model",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_Statuses_status_id",
                table: "item_request",
                column: "status_id",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_users_created_by",
                table: "item_request",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_users_modified_by",
                table: "item_request",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_users_user_id",
                table: "item_request",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_detail_item_model_item_model_id",
                table: "item_request_detail",
                column: "item_model_id",
                principalTable: "item_model",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_detail_item_request_ItemRequestId1",
                table: "item_request_detail",
                column: "ItemRequestId1",
                principalTable: "item_request",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_detail_item_request_item_request_id",
                table: "item_request_detail",
                column: "item_request_id",
                principalTable: "item_request",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_detail_users_created_by",
                table: "item_request_detail",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_request_detail_users_modified_by",
                table: "item_request_detail",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_type_users_created_by",
                table: "item_type",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_type_users_modified_by",
                table: "item_type",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_users_UserId",
                table: "purchase_request",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_users_created_by",
                table: "purchase_request",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_users_modified_by",
                table: "purchase_request",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_detail_item_model_item_model_id",
                table: "purchase_request_detail",
                column: "item_model_id",
                principalTable: "item_model",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_detail_purchase_request_purchase_request_id",
                table: "purchase_request_detail",
                column: "purchase_request_id",
                principalTable: "purchase_request",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_detail_users_created_by",
                table: "purchase_request_detail",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_Statuses_status_id",
                table: "return_request",
                column: "status_id",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_users_created_by",
                table: "return_request",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_users_modified_by",
                table: "return_request",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_users_user_id",
                table: "return_request",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_detail_item_model_item_model_id",
                table: "return_request_detail",
                column: "item_model_id",
                principalTable: "item_model",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_detail_return_request_return_request_id",
                table: "return_request_detail",
                column: "return_request_id",
                principalTable: "return_request",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_detail_users_created_by",
                table: "return_request_detail",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_detail_users_modified_by",
                table: "return_request_detail",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_CreatedBy",
                table: "roles",
                column: "CreatedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_ModifiedBy",
                table: "roles",
                column: "ModifiedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_CreatedBy",
                table: "users",
                column: "CreatedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_ModifiedBy",
                table: "users",
                column: "ModifiedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_model_item_request_detail_ItemRequestDetailId",
                table: "item_model");

            migrationBuilder.DropForeignKey(
                name: "FK_item_model_item_type_ItemTypeId1",
                table: "item_model");

            migrationBuilder.DropForeignKey(
                name: "FK_item_model_item_type_item_type_id",
                table: "item_model");

            migrationBuilder.DropForeignKey(
                name: "FK_item_model_users_created_by",
                table: "item_model");

            migrationBuilder.DropForeignKey(
                name: "FK_item_model_users_modified_by",
                table: "item_model");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_Statuses_status_id",
                table: "item_request");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_users_created_by",
                table: "item_request");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_users_modified_by",
                table: "item_request");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_users_user_id",
                table: "item_request");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_detail_item_model_item_model_id",
                table: "item_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_detail_item_request_ItemRequestId1",
                table: "item_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_detail_item_request_item_request_id",
                table: "item_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_detail_users_created_by",
                table: "item_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_item_request_detail_users_modified_by",
                table: "item_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_item_type_users_created_by",
                table: "item_type");

            migrationBuilder.DropForeignKey(
                name: "FK_item_type_users_modified_by",
                table: "item_type");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_users_UserId",
                table: "purchase_request");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_users_created_by",
                table: "purchase_request");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_users_modified_by",
                table: "purchase_request");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_detail_item_model_item_model_id",
                table: "purchase_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_detail_purchase_request_purchase_request_id",
                table: "purchase_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_detail_users_created_by",
                table: "purchase_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_Statuses_status_id",
                table: "return_request");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_users_created_by",
                table: "return_request");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_users_modified_by",
                table: "return_request");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_users_user_id",
                table: "return_request");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_detail_item_model_item_model_id",
                table: "return_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_detail_return_request_return_request_id",
                table: "return_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_detail_users_created_by",
                table: "return_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_detail_users_modified_by",
                table: "return_request_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_CreatedBy",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_ModifiedBy",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_users_CreatedBy",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_users_ModifiedBy",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_return_request_detail",
                table: "return_request_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_return_request",
                table: "return_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_request_detail",
                table: "purchase_request_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_request",
                table: "purchase_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_type",
                table: "item_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_request_detail",
                table: "item_request_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_request",
                table: "item_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_model",
                table: "item_model");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "return_request_detail",
                newName: "ReturnRequestDetails");

            migrationBuilder.RenameTable(
                name: "return_request",
                newName: "ReturnRequests");

            migrationBuilder.RenameTable(
                name: "purchase_request_detail",
                newName: "PurchaseRequestDetails");

            migrationBuilder.RenameTable(
                name: "purchase_request",
                newName: "PurchaseRequests");

            migrationBuilder.RenameTable(
                name: "item_type",
                newName: "ItemTypes");

            migrationBuilder.RenameTable(
                name: "item_request_detail",
                newName: "ItemRequestDetails");

            migrationBuilder.RenameTable(
                name: "item_request",
                newName: "ItemRequests");

            migrationBuilder.RenameTable(
                name: "item_model",
                newName: "ItemModels");

            migrationBuilder.RenameIndex(
                name: "IX_users_role_id",
                table: "Users",
                newName: "IX_Users_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_ModifiedBy",
                table: "Users",
                newName: "IX_Users_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_users_CreatedBy",
                table: "Users",
                newName: "IX_Users_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_roles_ModifiedBy",
                table: "Roles",
                newName: "IX_Roles_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_roles_CreatedBy",
                table: "Roles",
                newName: "IX_Roles_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_detail_return_request_id",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_return_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_detail_modified_by",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_detail_item_model_id",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_detail_created_by",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_created_by");

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
                name: "status_id",
                table: "ReturnRequests",
                newName: "StatusId");

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
                name: "IX_return_request_user_id",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_status_id",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_modified_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_created_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_detail_purchase_request_id",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_detail_item_model_id",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_detail_created_by",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_UserId",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_modified_by",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_created_by",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_type_modified_by",
                table: "ItemTypes",
                newName: "IX_ItemTypes_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_type_created_by",
                table: "ItemTypes",
                newName: "IX_ItemTypes_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_detail_modified_by",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_detail_ItemRequestId1",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_ItemRequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_detail_item_request_id",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_item_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_detail_item_model_id",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_detail_created_by",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_created_by");

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
                name: "status_id",
                table: "ItemRequests",
                newName: "StatusId");

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
                name: "IX_item_request_user_id",
                table: "ItemRequests",
                newName: "IX_ItemRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_status_id",
                table: "ItemRequests",
                newName: "IX_ItemRequests_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_modified_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_item_request_created_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_item_model_modified_by",
                table: "ItemModels",
                newName: "IX_ItemModels_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_model_ItemTypeId1",
                table: "ItemModels",
                newName: "IX_ItemModels_ItemTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_item_model_ItemRequestDetailId",
                table: "ItemModels",
                newName: "IX_ItemModels_ItemRequestDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_item_model_item_type_id",
                table: "ItemModels",
                newName: "IX_ItemModels_item_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_item_model_created_by",
                table: "ItemModels",
                newName: "IX_ItemModels_created_by");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnRequestDetails",
                table: "ReturnRequestDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnRequests",
                table: "ReturnRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequestDetails",
                table: "PurchaseRequestDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRequestDetails",
                table: "ItemRequestDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRequests",
                table: "ItemRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemModels",
                table: "ItemModels",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_ItemRequestDetails_ItemRequestDetailId",
                table: "ItemModels",
                column: "ItemRequestDetailId",
                principalTable: "ItemRequestDetails",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_ItemTypes_ItemTypeId1",
                table: "ItemModels",
                column: "ItemTypeId1",
                principalTable: "ItemTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_ItemTypes_item_type_id",
                table: "ItemModels",
                column: "item_type_id",
                principalTable: "ItemTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_Users_created_by",
                table: "ItemModels",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_Users_modified_by",
                table: "ItemModels",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemModels_item_model_id",
                table: "ItemRequestDetails",
                column: "item_model_id",
                principalTable: "ItemModels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId1",
                table: "ItemRequestDetails",
                column: "ItemRequestId1",
                principalTable: "ItemRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_item_request_id",
                table: "ItemRequestDetails",
                column: "item_request_id",
                principalTable: "ItemRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_Users_created_by",
                table: "ItemRequestDetails",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_Users_modified_by",
                table: "ItemRequestDetails",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ItemTypes_Users_created_by",
                table: "ItemTypes",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_Users_modified_by",
                table: "ItemTypes",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDetails_ItemModels_item_model_id",
                table: "PurchaseRequestDetails",
                column: "item_model_id",
                principalTable: "ItemModels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDetails_PurchaseRequests_purchase_request_id",
                table: "PurchaseRequestDetails",
                column: "purchase_request_id",
                principalTable: "PurchaseRequests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDetails_Users_created_by",
                table: "PurchaseRequestDetails",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_UserId",
                table: "PurchaseRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_created_by",
                table: "PurchaseRequests",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_modified_by",
                table: "PurchaseRequests",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_ItemModels_item_model_id",
                table: "ReturnRequestDetails",
                column: "item_model_id",
                principalTable: "ItemModels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_ReturnRequests_return_request_id",
                table: "ReturnRequestDetails",
                column: "return_request_id",
                principalTable: "ReturnRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_Users_created_by",
                table: "ReturnRequestDetails",
                column: "created_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_Users_modified_by",
                table: "ReturnRequestDetails",
                column: "modified_by",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedBy",
                table: "Roles",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_ModifiedBy",
                table: "Roles",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_role_id",
                table: "Users",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifiedBy",
                table: "Users",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
