using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopCln.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddeletableentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedOn",
                table: "Products",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Products",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOn",
                table: "ProductReviews",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "ProductReviews",
                newName: "CreatedOnUtc");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                table: "Products",
                newName: "LastModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Products",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                table: "ProductReviews",
                newName: "LastModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "ProductReviews",
                newName: "CreatedOn");
        }
    }
}
