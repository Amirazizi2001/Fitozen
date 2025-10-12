using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class M0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_packages_discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Warning = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolios_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comments_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_offers_packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_offers_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => new { x.PackagesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PackageProduct_packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProduct_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rates_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rates_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedProduct_products_ProductId",
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

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolioItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioItems_portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_portfolioItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "مکمل‌های ورزشی", null });

            migrationBuilder.InsertData(
                table: "factories",
                columns: new[] { "Id", "Country", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "آمریکا", null, "Optimum Nutrition (ON)" },
                    { 2, "آمریکا", null, "BSN (Bio-Engineered Supplements & Nutrition)" },
                    { 3, "آمریکا", null, "Cellucor (C4)" },
                    { 4, "کانادا/آمریکا", null, "MuscleTech" },
                    { 5, "آمریکا", null, "Dymatize Nutrition" },
                    { 6, "آمریکا", null, "Universal Nutrition" },
                    { 7, "آمریکا", null, "Animal (Universal Nutrition)" },
                    { 8, "آمریکا", null, "Gaspari Nutrition" },
                    { 9, "آمریکا", null, "Evlution Nutrition (EVL)" },
                    { 10, "آمریکا", null, "MusclePharm" },
                    { 11, "آمریکا", null, "Rule One Proteins" },
                    { 12, "آمریکا", null, "Redcon1" },
                    { 13, "آمریکا", null, "GAT Sport (German American Technologies)" },
                    { 14, "آمریکا", null, "Nutrex Research" },
                    { 15, "آمریکا", null, "ProSupps" },
                    { 16, "کانادا", null, "ALLMAX Nutrition" },
                    { 17, "آمریکا", null, "Kaged Muscle" },
                    { 18, "آمریکا", null, "RSP Nutrition" },
                    { 19, "آمریکا", null, "JYM Supplement Science" },
                    { 20, "آمریکا", null, "Performix" },
                    { 21, "بریتانیا", null, "Applied Nutrition" },
                    { 22, "آمریکا", null, "NOW Foods" },
                    { 23, "آمریکا", null, "GNC" },
                    { 24, "آمریکا", null, "Quest Nutrition" },
                    { 25, "آمریکا", null, "Nature's Best" },
                    { 26, "آمریکا", null, "Sports Research" },
                    { 27, "آمریکا", null, "BPN (Bare Performance Nutrition)" },
                    { 28, "استرالیا", null, "Fixx Nutrition" },
                    { 29, "بریتانیا", null, "Huel" },
                    { 30, "آمریکا", null, "G Fuel" },
                    { 31, "آمریکا", null, "Legion Athletics" },
                    { 32, "آمریکا", null, "1st Phorm" },
                    { 33, "آمریکا", null, "Alani Nu" },
                    { 34, "آمریکا", null, "Alpha Lion" },
                    { 35, "آمریکا", null, "AP Regimen" },
                    { 36, "آمریکا", null, "Axe & Sledge" },
                    { 37, "سوئد", null, "Barebells" },
                    { 38, "کانادا", null, "Biosteel" },
                    { 39, "آمریکا", null, "Built" },
                    { 40, "آمریکا", null, "Ronnie Coleman Signature Series" },
                    { 41, "هند", null, "HealthKart" },
                    { 42, "آمریکا", null, "Sporter.com" },
                    { 43, "آمریکا", null, "Bodybuilding.com" },
                    { 44, "آمریکا", null, "iHerb" },
                    { 45, "آمریکا", null, "Glanbia PLC" },
                    { 46, "سوئیس", null, "Nestlé" },
                    { 47, "آمریکا", null, "Abbott Laboratories" },
                    { 48, "آمریکا", null, "PepsiCo Inc." },
                    { 49, "آمریکا", null, "Coca-Cola Company" },
                    { 50, "اتریش", null, "Red Bull GmbH" },
                    { 51, "آمریکا", null, "Herbalife" },
                    { 52, "آمریکا", null, "Alticor Inc." },
                    { 53, "آمریکا", null, "Simply Good Foods Co." },
                    { 54, "چین", null, "Xiwang Group Co., Ltd" },
                    { 55, "آمریکا", null, "FitLife Brands" },
                    { 56, "آمریکا", null, "Post Holdings" },
                    { 57, "آمریکا", null, "Cizzle Brands Corporation" },
                    { 58, "آمریکا", null, "Mondelez International, Inc." },
                    { 59, "آمریکا", null, "Jarrow Formulas" },
                    { 60, "آمریکا", null, "Life Extension" },
                    { 61, "آمریکا", null, "Pure Encapsulations" },
                    { 62, "آمریکا", null, "Thorne Research" },
                    { 63, "آمریکا", null, "Designs for Health" },
                    { 64, "آمریکا", null, "NOW Sports" },
                    { 65, "پرتغال", null, "Prozis" },
                    { 66, "مجارستان", null, "Biotech USA" },
                    { 67, "مجارستان", null, "Scitec Nutrition" },
                    { 68, "چک", null, "Extrifit" },
                    { 69, "چک", null, "BigJoy Nutrition" },
                    { 70, "آلمان", null, "Weider Global Nutrition" },
                    { 71, "آلمان", null, "ESN (Elite Sports Nutrients)" },
                    { 72, "آلمان", null, "FitLine" },
                    { 73, "ژاپن", null, "Weider Japan" },
                    { 74, "ژاپن", null, "DNS (Daiwa Nutrition Supplements)" },
                    { 75, "ژاپن", null, "Meiji Co., Ltd." },
                    { 76, "ژاپن", null, "Orihiro Co., Ltd." },
                    { 77, "آمریکا", null, "Glanbia Performance Nutrition" },
                    { 78, "بریتانیا", null, "Maxinutrition" },
                    { 79, "بریتانیا", null, "Reflex Nutrition" },
                    { 80, "بریتانیا", null, "The Protein Works" },
                    { 81, "آفریقای جنوبی", null, "USN (Ultimate Sports Nutrition)" },
                    { 82, "آمریکا", null, "NutraBio" },
                    { 83, "آمریکا", null, "MHP (Maximum Human Performance)" },
                    { 84, "آمریکا", null, "NutriBiotic" },
                    { 85, "آمریکا", null, "Twinlab" },
                    { 86, "بریتانیا", null, "Vitabiotics" },
                    { 87, "آمریکا", null, "Nature’s Way" },
                    { 88, "آمریکا", null, "Solaray" },
                    { 89, "آمریکا", null, "Swanson Health Products" },
                    { 90, "آمریکا", null, "NutraKey" },
                    { 91, "آمریکا", null, "Vital Proteins" },
                    { 92, "آمریکا", null, "Ancient Nutrition" },
                    { 93, "آمریکا", null, "Orgain" },
                    { 94, "آمریکا", null, "Garden of Life" },
                    { 95, "آمریکا", null, "Ghost Lifestyle" },
                    { 96, "آمریکا", null, "Primeval Labs" },
                    { 97, "آمریکا", null, "MAN Sports" },
                    { 98, "آمریکا", null, "Isopure" },
                    { 99, "آمریکا", null, "CytoSport (Muscle Milk)" },
                    { 100, "آمریکا", null, "Xtend (Nutrabolt)" },
                    { 101, "ایتالیا", null, "Enervit S.p.A." },
                    { 102, "بریتانیا", null, "Myprotein" },
                    { 103, "استرالیا", null, "Swisse" },
                    { 104, "کانادا", null, "Bioriginal" },
                    { 105, "چین", null, "H&H Group" },
                    { 106, "آلمان", null, "Orthomol" },
                    { 107, "آمریکا", null, "Doctor’s Best" },
                    { 108, "آمریکا", null, "Source Naturals" },
                    { 109, "لهستان", null, "AllNutrition" },
                    { 110, "لهستان", null, "MuscleBear" },
                    { 111, "ایران", null, "کارن (PNC)" },
                    { 112, "ایران", null, "دوبیس (Dobis Nutrition)" },
                    { 113, "ایران", null, "کاله پرو" },
                    { 114, "ایران", null, "پگاه" },
                    { 115, "ایران", null, "نوتریمد" },
                    { 116, "ایران", null, "اپکس (Apex)" },
                    { 117, "ایران", null, "آلامو" },
                    { 118, "ایران", null, "ابوریحان" },
                    { 119, "ایران", null, "ادوی (Advay)" },
                    { 120, "ایران", null, "لوکس (LOOX)" },
                    { 121, "ایران", null, "های هلث (HiHealth)" },
                    { 122, "ایران", null, "پوراطب" },
                    { 123, "ایران", null, "نوتراکس (Nutrax)" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "Mobile", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role" },
                values: new object[,]
                {
                    { 1, null, "Amir.azizi1820@gmail.com", "Amir Azizi", "09382530590", "AQAAAAIAAYagAAAAEFEIAVgtkqrlU0buH3fzJT0aDupPd3d4YpB2OoPs247iNvswidO80jqkhiXhXI5f9w==", "o4N0YWnqgI8CqqLqvB+MZfV83gokJj4o7xkNxx5soKk=", null, "Admin" },
                    { 2, null, "Hussein.nakhostin2000@gmail.com", "Hussein Nakhostin", "09376700858", "AQAAAAIAAYagAAAAEAB1m2MwA1aqpNTOovEJPwzh/KM2F5QIUja/3RcYUcRGstUyI6BtG2aWQIu9q4UMCw==", "v5A3cXc7dpn5f0uDkQmL3ZThmLQXgb7F6t7+07r2iNk=", null, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, "پروتئین‌ها", 1 },
                    { 8, "آمینواسیدها", 1 },
                    { 15, "کراتین‌ها", 1 },
                    { 20, "گینرها (افزایش وزن)", 1 },
                    { 23, "چربی‌سوزها", 1 },
                    { 28, "مکمل‌های انرژی‌زا و پیش‌تمرین", 1 },
                    { 32, "ویتامین‌ها و مواد معدنی", 1 },
                    { 40, "اسیدهای چرب ضروری", 1 },
                    { 44, "مکمل‌های ریکاوری و سلامت مفاصل", 1 },
                    { 48, "مکمل‌های هورمونی", 1 },
                    { 52, "مکمل‌های ترکیبی و تخصصی", 1 },
                    { 56, "نوشیدنی‌ها و ژل‌های ورزشی", 1 },
                    { 3, "وی (Whey)", 2 },
                    { 4, "کازئین (Casein)", 2 },
                    { 5, "سویا (Soy)", 2 },
                    { 6, "پروتئین‌های گیاهی", 2 },
                    { 7, "پروتئین تخم‌مرغ / گوشت", 2 },
                    { 9, "BCAA", 8 },
                    { 10, "EAA", 8 },
                    { 11, "گلوتامین", 8 },
                    { 12, "آرژنین", 8 },
                    { 13, "بتاآلانین", 8 },
                    { 14, "کارنیتین", 8 },
                    { 16, "کراتین مونوهیدرات", 15 },
                    { 17, "کراتین HCL", 15 },
                    { 18, "کراتین میکرونایزد", 15 },
                    { 19, "کراتین‌های ترکیبی", 15 },
                    { 21, "مس گینر", 20 },
                    { 22, "کربو-پروتئین", 20 },
                    { 24, "ترموژنیک", 23 },
                    { 25, "L-Carnitine", 23 },
                    { 26, "CLA", 23 },
                    { 27, "بلوکرهای کربوهیدرات/چربی", 23 },
                    { 29, "پمپ (Nitric Oxide Boosters)", 28 },
                    { 30, "کافئین", 28 },
                    { 31, "ترکیبات محرک", 28 },
                    { 33, "مولتی‌ویتامین", 32 },
                    { 34, "ویتامین D", 32 },
                    { 35, "ویتامین C", 32 },
                    { 36, "ویتامین‌های گروه B", 32 },
                    { 37, "کلسیم", 32 },
                    { 38, "منیزیم", 32 },
                    { 39, "روی (Zinc)", 32 },
                    { 41, "امگا 3", 40 },
                    { 42, "امگا 6", 40 },
                    { 43, "امگا 9", 40 },
                    { 45, "گلوکوزامین", 44 },
                    { 46, "کندرویتین", 44 },
                    { 47, "MSM", 44 },
                    { 49, "بوستر تستوسترون", 48 },
                    { 50, "مهارکننده‌های استروژن", 48 },
                    { 51, "ZMA", 48 },
                    { 53, "پیش‌ورزش (Pre-Workout)", 52 },
                    { 54, "پس‌از‌ورزش (Post-Workout)", 52 },
                    { 55, "مولتی بلِند پروتئین", 52 },
                    { 57, "ایزوتونیک", 56 },
                    { 58, "ژل انرژی", 56 },
                    { 59, "نوشیدنی‌های پروتئینی آماده", 56 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_ParentId",
                table: "categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ParentId",
                table: "comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ProductId",
                table: "comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_offers_PackageId",
                table: "offers",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_offers_ProductId",
                table: "offers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_PortfolioId",
                table: "orders",
                column: "PortfolioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductsId",
                table: "PackageProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_packages_DiscountId",
                table: "packages",
                column: "DiscountId",
                unique: true,
                filter: "[DiscountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItems_PortfolioId",
                table: "portfolioItems",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItems_ProductId",
                table: "portfolioItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_UserId",
                table: "portfolios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_DiscountId",
                table: "products",
                column: "DiscountId",
                unique: true,
                filter: "[DiscountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_FactoryId",
                table: "products",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_ProductId",
                table: "productVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_rates_ProductId",
                table: "rates",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_rates_UserId",
                table: "rates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_ProductId",
                table: "RelatedProduct",
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
                name: "comments");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "portfolioItems");

            migrationBuilder.DropTable(
                name: "productVariants");

            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "RelatedProduct");

            migrationBuilder.DropTable(
                name: "supplementFacts");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "portfolios");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "factories");
        }
    }
}
