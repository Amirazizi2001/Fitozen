using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "NOW Foods");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "GNC");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Quest Nutrition");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Nature's Best");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Sports Research");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "BPN (Bare Performance Nutrition)");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Country", "Name" },
                values: new object[] { "استرالیا", "Fixx Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Huel" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "G Fuel" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Legion Athletics");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "1st Phorm");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Alani Nu");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Alpha Lion");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "AP Regimen");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Axe & Sledge");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Country", "Name" },
                values: new object[] { "سوئد", "Barebells" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Country", "Name" },
                values: new object[] { "کانادا", "Biosteel" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Built" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Ronnie Coleman Signature Series");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Country", "Name" },
                values: new object[] { "هند", "HealthKart" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Sporter.com" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Bodybuilding.com" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "iHerb");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Glanbia PLC");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Country", "Name" },
                values: new object[] { "سوئیس", "Nestlé" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Abbott Laboratories");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "PepsiCo Inc." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Coca-Cola Company");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Country", "Name" },
                values: new object[] { "اتریش", "Red Bull GmbH" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Herbalife");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Alticor Inc." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Simply Good Foods Co.");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چین", "Xiwang Group Co., Ltd" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "FitLife Brands");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Post Holdings" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Cizzle Brands Corporation");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Mondelez International, Inc.");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Jarrow Formulas");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Life Extension");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Pure Encapsulations");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Thorne Research" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "Designs for Health");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "NOW Sports");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Country", "Name" },
                values: new object[] { "پرتغال", "Prozis" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Country", "Name" },
                values: new object[] { "مجارستان", "Biotech USA" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Country", "Name" },
                values: new object[] { "مجارستان", "Scitec Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چک", "Extrifit" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چک", "BigJoy Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "Weider Global Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "ESN (Elite Sports Nutrients)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "FitLine" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "Weider Japan" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "DNS (Daiwa Nutrition Supplements)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "Meiji Co., Ltd." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "Orihiro Co., Ltd." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Glanbia Performance Nutrition");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Maxinutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Reflex Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "The Protein Works" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آفریقای جنوبی", "USN (Ultimate Sports Nutrition)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "NutraBio");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "MHP (Maximum Human Performance)");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "NutriBiotic");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Twinlab");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Vitabiotics" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Nature’s Way" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Solaray" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Swanson Health Products" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "NutraKey" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Vital Proteins" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Ancient Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Orgain" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Garden of Life" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Ghost Lifestyle" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Primeval Labs" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "MAN Sports" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Isopure" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 99,
                column: "Name",
                value: "CytoSport (Muscle Milk)");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Xtend (Nutrabolt)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایتالیا", "Enervit S.p.A." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 102,
                column: "Name",
                value: "Myprotein");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Country", "Name" },
                values: new object[] { "استرالیا", "Swisse" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Country", "Name" },
                values: new object[] { "کانادا", "Bioriginal" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چین", "H&H Group" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "Orthomol" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Doctor’s Best");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "Source Naturals");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Country", "Name" },
                values: new object[] { "لهستان", "AllNutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Country", "Name" },
                values: new object[] { "لهستان", "MuscleBear" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "کارن (PNC)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "دوبیس (Dobis Nutrition)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "کاله پرو" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "پگاه" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "نوتریمد" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "اپکس (Apex)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "آلامو" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "ابوریحان" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "ادوی (Advay)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "لوکس (LOOX)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "های هلث (HiHealth)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "پوراطب" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ایران", "نوتراکس (Nutrax)" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "ProSupps");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "NOW Foods");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "GNC");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Quest Nutrition");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Nature's Best");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Sports Research");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "BPN (Bare Performance Nutrition)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Country", "Name" },
                values: new object[] { "استرالیا", "Fixx Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Huel" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "G Fuel");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Legion Athletics");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "1st Phorm");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Alani Nu");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Alpha Lion");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "AP Regimen");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Axe & Sledge" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Country", "Name" },
                values: new object[] { "سوئد", "Barebells" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Country", "Name" },
                values: new object[] { "کانادا", "Biosteel" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Built");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Ronnie Coleman Signature Series" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Country", "Name" },
                values: new object[] { "هند", "HealthKart" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Country", "Name" },
                values: new object[] { "استرالیا", "Fixx Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Sporter.com");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Bodybuilding.com");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "iHerb" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Glanbia PLC");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Country", "Name" },
                values: new object[] { "سوئیس", "Nestlé" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Abbott Laboratories");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "PepsiCo Inc." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Coca-Cola Company");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Country", "Name" },
                values: new object[] { "اتریش", "Red Bull GmbH" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Herbalife");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Alticor Inc." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Simply Good Foods Co.");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چین", "Xiwang Group Co., Ltd" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "FitLife Brands");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Post Holdings");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Cizzle Brands Corporation");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Mondelez International, Inc.");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Glanbia PLC");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Country", "Name" },
                values: new object[] { "سوئیس", "Nestlé" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "Abbott Laboratories");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "PepsiCo Inc.");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Coca-Cola Company" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Country", "Name" },
                values: new object[] { "اتریش", "Red Bull GmbH" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Herbalife" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Alticor Inc." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Simply Good Foods Co." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چین", "Xiwang Group Co., Ltd" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "FitLife Brands" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Post Holdings" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Cizzle Brands Corporation" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Mondelez International, Inc." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Jarrow Formulas" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Life Extension" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "NOW Foods");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Nutrex Research" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Redcon1" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Kaged Muscle" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Pure Encapsulations" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "Thorne Research");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "Designs for Health");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "NOW Sports");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Nature’s Best");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Country", "Name" },
                values: new object[] { "پرتغال", "Prozis" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Country", "Name" },
                values: new object[] { "مجارستان", "Biotech USA" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Country", "Name" },
                values: new object[] { "مجارستان", "Scitec Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چک", "Extrifit" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Country", "Name" },
                values: new object[] { "چک", "BigJoy Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "Weider Global Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "ESN (Elite Sports Nutrients)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آلمان", "FitLine" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "Weider Japan" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "DNS (Daiwa Nutrition Supplements)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "Meiji Co., Ltd." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Country", "Name" },
                values: new object[] { "ژاپن", "Orihiro Co., Ltd." });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Country", "Name" },
                values: new object[] { "کانادا", "Allmax Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 99,
                column: "Name",
                value: "Glanbia Performance Nutrition");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Maxinutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Reflex Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 102,
                column: "Name",
                value: "Applied Nutrition");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "The Protein Works" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "MaxiNutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آفریقای جنوبی", "USN (Ultimate Sports Nutrition)" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "NutraBio" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "MHP (Maximum Human Performance)");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "MusclePharm");

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Cellucor" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Country", "Name" },
                values: new object[] { "کانادا/آمریکا", "MuscleTech" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "NutriBiotic" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Twinlab" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Country", "Name" },
                values: new object[] { "بریتانیا", "Vitabiotics" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Nature’s Way" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Solaray" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Swanson Health Products" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "NutraKey" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Vital Proteins" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Ancient Nutrition" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Orgain" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "Garden of Life" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "NutraBio Labs" });

            migrationBuilder.UpdateData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Country", "Name" },
                values: new object[] { "آمریکا", "RedCon1" });

            migrationBuilder.InsertData(
                table: "factories",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 124, "آمریکا", "Kaged Muscle" },
                    { 125, "آمریکا", "Legion Athletics" },
                    { 126, "آمریکا", "1st Phorm" },
                    { 127, "آمریکا", "Alani Nu" },
                    { 128, "آمریکا", "Ghost Lifestyle" },
                    { 129, "آمریکا", "Primeval Labs" },
                    { 130, "آمریکا", "MAN Sports" },
                    { 131, "آمریکا", "JYM Supplement Science" },
                    { 132, "آمریکا", "Isopure" },
                    { 133, "آمریکا", "CytoSport (Muscle Milk)" },
                    { 134, "آمریکا", "GAT Sport" },
                    { 135, "آمریکا", "RSP Nutrition" },
                    { 136, "آمریکا", "Xtend (Nutrabolt)" },
                    { 137, "آمریکا", "Nature’s Best" },
                    { 138, "آمریکا", "Herbalife" },
                    { 139, "آمریکا", "Abbott Laboratories" },
                    { 140, "ایتالیا", "Enervit S.p.A." }
                });
        }
    }
}
