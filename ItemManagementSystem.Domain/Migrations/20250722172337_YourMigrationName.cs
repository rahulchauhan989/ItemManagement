using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class YourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_models_item_types_ItemTypeId1",
                table: "item_models");

            migrationBuilder.DropForeignKey(
                name: "FK_item_models_item_types_item_type_id",
                table: "item_models");

            migrationBuilder.DropForeignKey(
                name: "FK_item_models_request_item_details_ItemRequestDetailId",
                table: "item_models");

            migrationBuilder.DropForeignKey(
                name: "FK_item_models_users_created_by",
                table: "item_models");

            migrationBuilder.DropForeignKey(
                name: "FK_item_models_users_modified_by",
                table: "item_models");

            migrationBuilder.DropForeignKey(
                name: "FK_item_types_users_created_by",
                table: "item_types");

            migrationBuilder.DropForeignKey(
                name: "FK_item_types_users_modified_by",
                table: "item_types");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_request_item_details_item_models_item_model_id",
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
                name: "FK_request_item_details_item_models_item_model_id",
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
                name: "FK_return_request_item_details_item_models_item_model_id",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_types",
                table: "item_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_models",
                table: "item_models");

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

            migrationBuilder.RenameTable(
                name: "item_types",
                newName: "ItemTypes");

            migrationBuilder.RenameTable(
                name: "item_models",
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
                name: "IX_return_request_records_user_id",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_records_modified_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_records_created_by",
                table: "ReturnRequests",
                newName: "IX_ReturnRequests_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_return_request_id",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_return_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_modified_by",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_item_model_id",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_return_request_item_details_created_by",
                table: "ReturnRequestDetails",
                newName: "IX_ReturnRequestDetails_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_records_user_id",
                table: "ItemRequests",
                newName: "IX_ItemRequests_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_records_modified_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_records_created_by",
                table: "ItemRequests",
                newName: "IX_ItemRequests_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_modified_by",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_ItemRequestId1",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_ItemRequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_item_request_id",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_item_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_item_model_id",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_request_item_details_created_by",
                table: "ItemRequestDetails",
                newName: "IX_ItemRequestDetails_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_records_UserId",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_records_modified_by",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_records_created_by",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_item_details_purchase_request_id",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_item_details_item_model_id",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_request_item_details_created_by",
                table: "PurchaseRequestDetails",
                newName: "IX_PurchaseRequestDetails_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_types_modified_by",
                table: "ItemTypes",
                newName: "IX_ItemTypes_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_types_created_by",
                table: "ItemTypes",
                newName: "IX_ItemTypes_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_models_modified_by",
                table: "ItemModels",
                newName: "IX_ItemModels_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_item_models_ItemTypeId1",
                table: "ItemModels",
                newName: "IX_ItemModels_ItemTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_item_models_ItemRequestDetailId",
                table: "ItemModels",
                newName: "IX_ItemModels_ItemRequestDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_item_models_item_type_id",
                table: "ItemModels",
                newName: "IX_ItemModels_item_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_item_models_created_by",
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
                name: "PK_ReturnRequests",
                table: "ReturnRequests",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnRequestDetails",
                table: "ReturnRequestDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRequests",
                table: "ItemRequests",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRequestDetails",
                table: "ItemRequestDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequestDetails",
                table: "PurchaseRequestDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes",
                column: "id");

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
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequestDetails_ItemRequests_item_request_id",
                table: "ItemRequestDetails",
                column: "item_request_id",
                principalTable: "ItemRequests",
                principalColumn: "id",
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
                principalColumn: "id",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_ItemRequests_Users_created_by",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_modified_by",
                table: "ItemRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequests_Users_user_id",
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
                name: "FK_ReturnRequests_Users_created_by",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_modified_by",
                table: "ReturnRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Users_user_id",
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
                newName: "return_request_records");

            migrationBuilder.RenameTable(
                name: "ReturnRequestDetails",
                newName: "return_request_item_details");

            migrationBuilder.RenameTable(
                name: "PurchaseRequests",
                newName: "purchase_request_records");

            migrationBuilder.RenameTable(
                name: "PurchaseRequestDetails",
                newName: "purchase_request_item_details");

            migrationBuilder.RenameTable(
                name: "ItemTypes",
                newName: "item_types");

            migrationBuilder.RenameTable(
                name: "ItemRequests",
                newName: "request_item_records");

            migrationBuilder.RenameTable(
                name: "ItemRequestDetails",
                newName: "request_item_details");

            migrationBuilder.RenameTable(
                name: "ItemModels",
                newName: "item_models");

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

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_user_id",
                table: "return_request_records",
                newName: "IX_return_request_records_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_modified_by",
                table: "return_request_records",
                newName: "IX_return_request_records_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequests_created_by",
                table: "return_request_records",
                newName: "IX_return_request_records_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_return_request_id",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_return_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_modified_by",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_item_model_id",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnRequestDetails_created_by",
                table: "return_request_item_details",
                newName: "IX_return_request_item_details_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_UserId",
                table: "purchase_request_records",
                newName: "IX_purchase_request_records_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_modified_by",
                table: "purchase_request_records",
                newName: "IX_purchase_request_records_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_created_by",
                table: "purchase_request_records",
                newName: "IX_purchase_request_records_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_purchase_request_id",
                table: "purchase_request_item_details",
                newName: "IX_purchase_request_item_details_purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_item_model_id",
                table: "purchase_request_item_details",
                newName: "IX_purchase_request_item_details_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDetails_created_by",
                table: "purchase_request_item_details",
                newName: "IX_purchase_request_item_details_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypes_modified_by",
                table: "item_types",
                newName: "IX_item_types_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypes_created_by",
                table: "item_types",
                newName: "IX_item_types_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_user_id",
                table: "request_item_records",
                newName: "IX_request_item_records_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_modified_by",
                table: "request_item_records",
                newName: "IX_request_item_records_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequests_created_by",
                table: "request_item_records",
                newName: "IX_request_item_records_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_modified_by",
                table: "request_item_details",
                newName: "IX_request_item_details_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_ItemRequestId1",
                table: "request_item_details",
                newName: "IX_request_item_details_ItemRequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_item_request_id",
                table: "request_item_details",
                newName: "IX_request_item_details_item_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_item_model_id",
                table: "request_item_details",
                newName: "IX_request_item_details_item_model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRequestDetails_created_by",
                table: "request_item_details",
                newName: "IX_request_item_details_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_modified_by",
                table: "item_models",
                newName: "IX_item_models_modified_by");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_ItemTypeId1",
                table: "item_models",
                newName: "IX_item_models_ItemTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_ItemRequestDetailId",
                table: "item_models",
                newName: "IX_item_models_ItemRequestDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_item_type_id",
                table: "item_models",
                newName: "IX_item_models_item_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModels_created_by",
                table: "item_models",
                newName: "IX_item_models_created_by");

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
                name: "PK_purchase_request_records",
                table: "purchase_request_records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_request_item_details",
                table: "purchase_request_item_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_types",
                table: "item_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_request_item_records",
                table: "request_item_records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_request_item_details",
                table: "request_item_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_models",
                table: "item_models",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_models_item_types_ItemTypeId1",
                table: "item_models",
                column: "ItemTypeId1",
                principalTable: "item_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_models_item_types_item_type_id",
                table: "item_models",
                column: "item_type_id",
                principalTable: "item_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_models_request_item_details_ItemRequestDetailId",
                table: "item_models",
                column: "ItemRequestDetailId",
                principalTable: "request_item_details",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_models_users_created_by",
                table: "item_models",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_models_users_modified_by",
                table: "item_models",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_types_users_created_by",
                table: "item_types",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_types_users_modified_by",
                table: "item_types",
                column: "modified_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_request_item_details_item_models_item_model_id",
                table: "purchase_request_item_details",
                column: "item_model_id",
                principalTable: "item_models",
                principalColumn: "id",
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
                name: "FK_request_item_details_item_models_item_model_id",
                table: "request_item_details",
                column: "item_model_id",
                principalTable: "item_models",
                principalColumn: "id",
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
                name: "FK_return_request_item_details_item_models_item_model_id",
                table: "return_request_item_details",
                column: "item_model_id",
                principalTable: "item_models",
                principalColumn: "id",
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
    }
}
