using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeCategory",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductForm",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "Efficiency",
                table: "products",
                newName: "Warning");

            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "portfolioItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "productVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VariantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serving = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productVariants_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supplementFacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facts = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplementFacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplementFacts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_ProductId",
                table: "productVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_supplementFacts_ProductId",
                table: "supplementFacts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productVariants");

            migrationBuilder.DropTable(
                name: "supplementFacts");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "portfolioItems");

            migrationBuilder.RenameColumn(
                name: "Warning",
                table: "products",
                newName: "Efficiency");

            migrationBuilder.AddColumn<int>(
                name: "AgeCategory",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductForm",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "products",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }
    }
}
