using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfTableAndCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_ItemRequestDetails_ItemRequestDetailId",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_Users_CreatedBy",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_Users_ModifiedBy",
                table: "ItemModels");

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
                name: "FK_ItemTypes_Users_CreatedBy",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_Users_ModifiedBy",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDetails_ItemModels_ItemModelId",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDetails_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDetails_Users_CreatedBy",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_CreatedBy",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_ModifiedBy",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_UserId",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemModels_ItemModelId",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_ItemRequestId1",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_Users_CreatedBy",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequestDetails_Users_ModifiedBy",
                table: "ItemRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_ItemModels_ItemModelId",
                table: "ReturnRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_ReturnRequests_ReturnRequestId",
                table: "ReturnRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_Users_CreatedBy",
                table: "ReturnRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequestDetails_Users_ModifiedBy",
                table: "ReturnRequestDetails");

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
                name: "FK_Users_Roles_RoleId",
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
                name: "PK_ItemRequestDetails",
                table: "ItemRequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequestDetails",
                table: "PurchaseRequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRequests",
                table: "ItemRequests");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "ReturnRequests",
                newName: "return_request_records");

            migrationBuilder.RenameTable(
                name: "ReturnRequestDetails",
                newName: "return_request_item_details");

            migrationBuilder.RenameTable(
                name: "ItemRequestDetails",
                newName: "request_item_details");

            migrationBuilder.RenameTable(
                name: "PurchaseRequests",
                newName: "purchase_request_records");

            migrationBuilder.RenameTable(
                name: "PurchaseRequestDetails",
                newName: "purchase_request_item_details");

            migrationBuilder.RenameTable(
                name: "ItemRequests",
                newName: "request_item_records");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "users",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "users",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "users",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ModifiedBy",
                table: "users",
                newName: "IX_users_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CreatedBy",
                table: "users",
                newName: "IX_users_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "users",
                newName: "IX_users_role_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "roles",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "roles",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "roles",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_ModifiedBy",
                table: "roles",
                newName: "IX_roles_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_CreatedBy",
                table: "roles",
                newName: "IX_roles_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "return_request_records",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "return_request_records",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "return_request_records",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "return_request_records",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReturnRequestNumber",
                table: "return_request_records",
                newName: "return_request_number");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "return_request_records",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "return_request_records",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "return_request_records",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "return_request_records",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_UserId",
                table: "return_request_records",
                newName: "IX_return_request_records_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_ModifiedBy",
                table: "return_request_records",
                newName: "IX_return_request_records_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_CreatedBy",
                table: "return_request_records",
                newName: "IX_return_request_records_created_by");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "return_request_item_details",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "return_request_item_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "return_request_item_details",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReturnRequestId",
                table: "return_request_item_details",
                newName: "return_request_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "return_request_item_details",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "ItemModelId",
                table: "return_request_item_details",
                newName: "item_model_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "return_request_item_details",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "return_request_item_details",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "return_request_item_details",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_ReturnRequestId",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_return_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_ModifiedBy",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_ItemModelId",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_CreatedBy",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_created_by");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "request_item_details",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "request_item_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "request_item_details",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "request_item_details",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "ItemRequestId",
                table: "request_item_details",
                newName: "item_request_id");

            migrationBuilder.RenameColumn(
                name: "ItemModelId",
                table: "request_item_details",
                newName: "item_model_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "request_item_details",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "request_item_details",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "request_item_details",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_ModifiedBy",
                table: "request_item_details",
                newName: "IX_request_item_details_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_ItemRequestId1",
                table: "request_item_details",
                newName: "IX_request_item_details_ItemRequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_ItemRequestId",
                table: "request_item_details",
                newName: "IX_request_item_details_item_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_ItemModelId",
                table: "request_item_details",
                newName: "IX_request_item_details_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_CreatedBy",
                table: "request_item_details",
                newName: "IX_request_item_details_created_by");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "purchase_request_records",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "purchase_request_records",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "purchase_request_records",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "purchase_request_records",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "purchase_request_records",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "purchase_request_records",
                newName: "invoice_number");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "purchase_request_records",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "purchase_request_records",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_UserId",
                table: "purchase_request_records",
                newName: "IX_purchase_request_records_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_ModifiedBy",
                table: "purchase_request_records",
                newName: "IX_purchase_request_records_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_CreatedBy",
                table: "purchase_request_records",
                newName: "IX_purchase_request_records_created_by");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "purchase_request_item_details",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "purchase_request_item_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestId",
                table: "purchase_request_item_details",
                newName: "purchase_request_id");

            migrationBuilder.RenameColumn(
                name: "ItemModelId",
                table: "purchase_request_item_details",
                newName: "item_model_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "purchase_request_item_details",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "purchase_request_item_details",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "purchase_request_item_details",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_PurchaseRequestId",
                table: "purchase_request_item_details",
                newName: "IX_purchase_request_item_details_purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_ItemModelId",
                table: "purchase_request_item_details",
                newName: "IX_purchase_request_item_details_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_CreatedBy",
                table: "purchase_request_item_details",
                newName: "IX_purchase_request_item_details_created_by");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "request_item_records",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "request_item_records",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "request_item_records",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "request_item_records",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "request_item_records",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "request_item_records",
                newName: "request_number");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "request_item_records",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "request_item_records",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "request_item_records",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "request_item_records",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_UserId",
                table: "request_item_records",
                newName: "IX_request_item_records_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_ModifiedBy",
                table: "request_item_records",
                newName: "IX_request_item_records_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_CreatedBy",
                table: "request_item_records",
                newName: "IX_request_item_records_created_by");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_return_request_records",
                table: "return_request_records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_return_request_item_details",
                table: "return_request_item_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_request_item_details",
                table: "request_item_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_request_records",
                table: "purchase_request_records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_request_item_details",
                table: "purchase_request_item_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_request_item_records",
                table: "request_item_records",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_request_item_details_ItemRequestDetailId",
                table: "ItemModels",
                column: "ItemRequestDetailId",
                principalTable: "request_item_details",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_users_CreatedBy",
                table: "ItemModels",
                column: "CreatedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_users_ModifiedBy",
                table: "ItemModels",
                column: "ModifiedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_users_CreatedBy",
                table: "ItemTypes",
                column: "CreatedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_users_ModifiedBy",
                table: "ItemTypes",
                column: "ModifiedBy",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_item_details_ItemModels_item_model_id",
                table: "purchase_request_item_details",
                column: "item_model_id",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_item_details_purchase_request_records_purc~",
                table: "purchase_request_item_details",
                column: "purchase_request_id",
                principalTable: "purchase_request_records",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_item_details_users_created_by",
                table: "purchase_request_item_details",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_records_users_UserId",
                table: "purchase_request_records",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_records_users_created_by",
                table: "purchase_request_records",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_records_users_modified_by",
                table: "purchase_request_records",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_details_ItemModels_item_model_id",
                table: "request_item_details",
                column: "item_model_id",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_details_request_item_records_ItemRequestId1",
                table: "request_item_details",
                column: "ItemRequestId1",
                principalTable: "request_item_records",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_details_request_item_records_item_request_id",
                table: "request_item_details",
                column: "item_request_id",
                principalTable: "request_item_records",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_details_users_created_by",
                table: "request_item_details",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_details_users_modified_by",
                table: "request_item_details",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_records_users_created_by",
                table: "request_item_records",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_records_users_modified_by",
                table: "request_item_records",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_request_item_records_users_user_id",
                table: "request_item_records",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_item_details_ItemModels_item_model_id",
                table: "return_request_item_details",
                column: "item_model_id",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_item_details_return_request_records_return_r~",
                table: "return_request_item_details",
                column: "return_request_id",
                principalTable: "return_request_records",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_item_details_users_created_by",
                table: "return_request_item_details",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_item_details_users_modified_by",
                table: "return_request_item_details",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_records_users_created_by",
                table: "return_request_records",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_records_users_modified_by",
                table: "return_request_records",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_request_records_users_user_id",
                table: "return_request_records",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ItemModels_request_item_details_ItemRequestDetailId",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_users_CreatedBy",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemModels_users_ModifiedBy",
                table: "ItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_users_CreatedBy",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_users_ModifiedBy",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_item_details_ItemModels_item_model_id",
                table: "purchase_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_item_details_purchase_request_records_purc~",
                table: "purchase_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_item_details_users_created_by",
                table: "purchase_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_records_users_UserId",
                table: "purchase_request_records");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_records_users_created_by",
                table: "purchase_request_records");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_records_users_modified_by",
                table: "purchase_request_records");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_details_ItemModels_item_model_id",
                table: "request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_details_request_item_records_ItemRequestId1",
                table: "request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_details_request_item_records_item_request_id",
                table: "request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_details_users_created_by",
                table: "request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_details_users_modified_by",
                table: "request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_records_users_created_by",
                table: "request_item_records");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_records_users_modified_by",
                table: "request_item_records");

            migrationBuilder.DropForeignKey(
                name: "FK_request_item_records_users_user_id",
                table: "request_item_records");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_item_details_ItemModels_item_model_id",
                table: "return_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_item_details_return_request_records_return_r~",
                table: "return_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_item_details_users_created_by",
                table: "return_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_item_details_users_modified_by",
                table: "return_request_item_details");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_records_users_created_by",
                table: "return_request_records");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_records_users_modified_by",
                table: "return_request_records");

            migrationBuilder.DropForeignKey(
                name: "FK_return_request_records_users_user_id",
                table: "return_request_records");

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
                name: "PK_return_request_records",
                table: "return_request_records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_return_request_item_details",
                table: "return_request_item_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_request_item_records",
                table: "request_item_records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_request_item_details",
                table: "request_item_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_request_records",
                table: "purchase_request_records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_request_item_details",
                table: "purchase_request_item_details");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "return_request_records",
                newName: "ReturnRequests");

            migrationBuilder.RenameTable(
                name: "return_request_item_details",
                newName: "ReturnRequestDetails");

            migrationBuilder.RenameTable(
                name: "request_item_records",
                newName: "ItemRequests");

            migrationBuilder.RenameTable(
                name: "request_item_details",
                newName: "ItemRequestDetails");

            migrationBuilder.RenameTable(
                name: "purchase_request_records",
                newName: "PurchaseRequests");

            migrationBuilder.RenameTable(
                name: "purchase_request_item_details",
                newName: "PurchaseRequestDetails");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Users",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_users_ModifiedBy",
                table: "Users",
                newName: "IX_Users_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_users_CreatedBy",
                table: "Users",
                newName: "IX_Users_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_users_role_id",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Roles",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Roles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Roles",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_roles_ModifiedBy",
                table: "Roles",
                newName: "IX_Roles_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_roles_CreatedBy",
                table: "Roles",
                newName: "IX_Roles_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ReturnRequests",
                newName: "Status");

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
                name: "IX_return_request_records_user_id",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_records_modified_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_records_created_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "ReturnRequestDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ReturnRequestDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ReturnRequestDetails",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "return_request_id",
                table: "ReturnRequestDetails",
                newName: "ReturnRequestId");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "ReturnRequestDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "item_model_id",
                table: "ReturnRequestDetails",
                newName: "ItemModelId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ReturnRequestDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ReturnRequestDetails",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ReturnRequestDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_return_request_id",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_ReturnRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_modified_by",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_item_model_id",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_ItemModelId");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_created_by",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ItemRequests",
                newName: "Status");

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
                name: "IX_request_item_records_user_id",
                table: "ItemRequests",
                newName: "IX_ItemRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_records_modified_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_records_created_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "ItemRequestDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ItemRequestDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ItemRequestDetails",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "ItemRequestDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "item_request_id",
                table: "ItemRequestDetails",
                newName: "ItemRequestId");

            migrationBuilder.RenameColumn(
                name: "item_model_id",
                table: "ItemRequestDetails",
                newName: "ItemModelId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ItemRequestDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ItemRequestDetails",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ItemRequestDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_modified_by",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_ItemRequestId1",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_ItemRequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_item_request_id",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_ItemRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_item_model_id",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_ItemModelId");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_created_by",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "PurchaseRequests",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PurchaseRequests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PurchaseRequests",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "PurchaseRequests",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PurchaseRequests",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "invoice_number",
                table: "PurchaseRequests",
                newName: "InvoiceNumber");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "PurchaseRequests",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PurchaseRequests",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_records_UserId",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_records_modified_by",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_records_created_by",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "PurchaseRequestDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PurchaseRequestDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "purchase_request_id",
                table: "PurchaseRequestDetails",
                newName: "PurchaseRequestId");

            migrationBuilder.RenameColumn(
                name: "item_model_id",
                table: "PurchaseRequestDetails",
                newName: "ItemModelId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "PurchaseRequestDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "PurchaseRequestDetails",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PurchaseRequestDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_item_details_purchase_request_id",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_PurchaseRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_item_details_item_model_id",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_ItemModelId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_item_details_created_by",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnRequests",
                table: "ReturnRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnRequestDetails",
                table: "ReturnRequestDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRequests",
                table: "ItemRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRequestDetails",
                table: "ItemRequestDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequestDetails",
                table: "PurchaseRequestDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_ItemRequestDetails_ItemRequestDetailId",
                table: "ItemModels",
                column: "ItemRequestDetailId",
                principalTable: "ItemRequestDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_Users_CreatedBy",
                table: "ItemModels",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModels_Users_ModifiedBy",
                table: "ItemModels",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_CreatedBy",
                table: "ItemRequests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_ModifiedBy",
                table: "ItemRequests",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequests_Users_UserId",
                table: "ItemRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_Users_CreatedBy",
                table: "ItemTypes",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_Users_ModifiedBy",
                table: "ItemTypes",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDetails_ItemModels_ItemModelId",
                table: "PurchaseRequestDetails",
                column: "ItemModelId",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDetails_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseRequestDetails",
                column: "PurchaseRequestId",
                principalTable: "PurchaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDetails_Users_CreatedBy",
                table: "PurchaseRequestDetails",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_CreatedBy",
                table: "PurchaseRequests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_ModifiedBy",
                table: "PurchaseRequests",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_UserId",
                table: "PurchaseRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemModels_ItemModelId",
                table: "ItemRequestDetails",
                column: "ItemModelId",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_Users_CreatedBy",
                table: "ItemRequestDetails",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_Users_ModifiedBy",
                table: "ItemRequestDetails",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_ItemModels_ItemModelId",
                table: "ReturnRequestDetails",
                column: "ItemModelId",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_ReturnRequests_ReturnRequestId",
                table: "ReturnRequestDetails",
                column: "ReturnRequestId",
                principalTable: "ReturnRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_Users_CreatedBy",
                table: "ReturnRequestDetails",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequestDetails_Users_ModifiedBy",
                table: "ReturnRequestDetails",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_CreatedBy",
                table: "ReturnRequests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_ModifiedBy",
                table: "ReturnRequests",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Users_UserId",
                table: "ReturnRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedBy",
                table: "Roles",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_ModifiedBy",
                table: "Roles",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifiedBy",
                table: "Users",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
