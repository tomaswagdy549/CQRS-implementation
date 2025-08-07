using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class converttostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");
            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products");
            migrationBuilder.DropPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes");
            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");
            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "productTypes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductTypeId",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "brands",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
            migrationBuilder.AddPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes",
                column: "Id");
            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "Id");
            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "productTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeId",
                table: "products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "brands",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "Id");
        }
    }
}
