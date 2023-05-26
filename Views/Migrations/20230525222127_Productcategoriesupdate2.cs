using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Views.Migrations
{
    /// <inheritdoc />
    public partial class Productcategoriesupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoriesMiddle_ProductCategories_CategoryId",
                table: "ProductCategoriesMiddle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoriesMiddle_Products_ProductId",
                table: "ProductCategoriesMiddle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategoriesMiddle",
                table: "ProductCategoriesMiddle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategoriesMiddle",
                newName: "ProductsCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoriesMiddle_CategoryId",
                table: "ProductsCategory",
                newName: "IX_ProductsCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsCategory",
                table: "ProductsCategory",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCategory_Category_CategoryId",
                table: "ProductsCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCategory_Products_ProductId",
                table: "ProductsCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCategory_Category_CategoryId",
                table: "ProductsCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCategory_Products_ProductId",
                table: "ProductsCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsCategory",
                table: "ProductsCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "ProductsCategory",
                newName: "ProductCategoriesMiddle");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "ProductCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsCategory_CategoryId",
                table: "ProductCategoriesMiddle",
                newName: "IX_ProductCategoriesMiddle_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategoriesMiddle",
                table: "ProductCategoriesMiddle",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoriesMiddle_ProductCategories_CategoryId",
                table: "ProductCategoriesMiddle",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoriesMiddle_Products_ProductId",
                table: "ProductCategoriesMiddle",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
