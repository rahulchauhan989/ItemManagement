﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemManagementSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemRequests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
