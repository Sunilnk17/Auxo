﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auxo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
