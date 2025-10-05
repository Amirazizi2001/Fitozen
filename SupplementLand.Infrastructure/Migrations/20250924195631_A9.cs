using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "مکمل‌های ورزشی", null });

            migrationBuilder.InsertData(
                table: "factories",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "آمریکا", "Optimum Nutrition (ON)" },
                    { 2, "آمریکا", "BSN (Bio-Engineered Supplements & Nutrition)" },
                    { 3, "آمریکا", "Cellucor (C4)" },
                    { 4, "کانادا/آمریکا", "MuscleTech" },
                    { 5, "آمریکا", "Dymatize Nutrition" },
                    { 6, "آمریکا", "Universal Nutrition" },
                    { 7, "آمریکا", "Animal (Universal Nutrition)" },
                    { 8, "آمریکا", "Gaspari Nutrition" },
                    { 9, "آمریکا", "Evlution Nutrition (EVL)" },
                    { 10, "آمریکا", "MusclePharm" },
                    { 11, "آمریکا", "Rule One Proteins" },
                    { 12, "آمریکا", "Redcon1" },
                    { 13, "آمریکا", "GAT Sport (German American Technologies)" },
                    { 14, "آمریکا", "Nutrex Research" },
                    { 15, "آمریکا", "ProSupps" },
                    { 16, "کانادا", "ALLMAX Nutrition" },
                    { 17, "آمریکا", "Kaged Muscle" },
                    { 18, "آمریکا", "RSP Nutrition" },
                    { 19, "آمریکا", "JYM Supplement Science" },
                    { 20, "آمریکا", "Performix" },
                    { 21, "بریتانیا", "Applied Nutrition" },
                    { 22, "آمریکا", "ProSupps" },
                    { 23, "آمریکا", "NOW Foods" },
                    { 24, "آمریکا", "GNC" },
                    { 25, "آمریکا", "Quest Nutrition" },
                    { 26, "آمریکا", "Nature's Best" },
                    { 27, "آمریکا", "Sports Research" },
                    { 28, "آمریکا", "BPN (Bare Performance Nutrition)" },
                    { 29, "استرالیا", "Fixx Nutrition" },
                    { 30, "بریتانیا", "Huel" },
                    { 31, "آمریکا", "G Fuel" },
                    { 32, "آمریکا", "Legion Athletics" },
                    { 33, "آمریکا", "1st Phorm" },
                    { 34, "آمریکا", "Alani Nu" },
                    { 35, "آمریکا", "Alpha Lion" },
                    { 36, "آمریکا", "AP Regimen" },
                    { 37, "آمریکا", "Axe & Sledge" },
                    { 38, "سوئد", "Barebells" },
                    { 39, "کانادا", "Biosteel" },
                    { 40, "آمریکا", "Built" },
                    { 41, "آمریکا", "Ronnie Coleman Signature Series" },
                    { 42, "هند", "HealthKart" },
                    { 43, "استرالیا", "Fixx Nutrition" },
                    { 44, "آمریکا", "Sporter.com" },
                    { 45, "آمریکا", "Bodybuilding.com" },
                    { 46, "آمریکا", "iHerb" },
                    { 47, "آمریکا", "Glanbia PLC" },
                    { 48, "سوئیس", "Nestlé" },
                    { 49, "آمریکا", "Abbott Laboratories" },
                    { 50, "آمریکا", "PepsiCo Inc." },
                    { 51, "آمریکا", "Coca-Cola Company" },
                    { 52, "اتریش", "Red Bull GmbH" },
                    { 53, "آمریکا", "Herbalife" },
                    { 54, "آمریکا", "Alticor Inc." },
                    { 55, "آمریکا", "Simply Good Foods Co." },
                    { 56, "چین", "Xiwang Group Co., Ltd" },
                    { 57, "آمریکا", "FitLife Brands" },
                    { 58, "آمریکا", "Post Holdings" },
                    { 59, "آمریکا", "Cizzle Brands Corporation" },
                    { 60, "آمریکا", "Mondelez International, Inc." },
                    { 61, "آمریکا", "Glanbia PLC" },
                    { 62, "سوئیس", "Nestlé" },
                    { 63, "آمریکا", "Abbott Laboratories" },
                    { 64, "آمریکا", "PepsiCo Inc." },
                    { 65, "آمریکا", "Coca-Cola Company" },
                    { 66, "اتریش", "Red Bull GmbH" },
                    { 67, "آمریکا", "Herbalife" },
                    { 68, "آمریکا", "Alticor Inc." },
                    { 69, "آمریکا", "Simply Good Foods Co." },
                    { 70, "چین", "Xiwang Group Co., Ltd" },
                    { 71, "آمریکا", "FitLife Brands" },
                    { 72, "آمریکا", "Post Holdings" },
                    { 73, "آمریکا", "Cizzle Brands Corporation" },
                    { 74, "آمریکا", "Mondelez International, Inc." },
                    { 75, "آمریکا", "Jarrow Formulas" },
                    { 76, "آمریکا", "Life Extension" },
                    { 77, "آمریکا", "NOW Foods" },
                    { 78, "آمریکا", "Nutrex Research" },
                    { 79, "آمریکا", "Redcon1" },
                    { 80, "آمریکا", "Kaged Muscle" },
                    { 81, "آمریکا", "Pure Encapsulations" },
                    { 82, "آمریکا", "Thorne Research" },
                    { 83, "آمریکا", "Designs for Health" },
                    { 84, "آمریکا", "NOW Sports" },
                    { 85, "آمریکا", "Nature’s Best" },
                    { 86, "پرتغال", "Prozis" },
                    { 87, "مجارستان", "Biotech USA" },
                    { 88, "مجارستان", "Scitec Nutrition" },
                    { 89, "چک", "Extrifit" },
                    { 90, "چک", "BigJoy Nutrition" },
                    { 91, "آلمان", "Weider Global Nutrition" },
                    { 92, "آلمان", "ESN (Elite Sports Nutrients)" },
                    { 93, "آلمان", "FitLine" },
                    { 94, "ژاپن", "Weider Japan" },
                    { 95, "ژاپن", "DNS (Daiwa Nutrition Supplements)" },
                    { 96, "ژاپن", "Meiji Co., Ltd." },
                    { 97, "ژاپن", "Orihiro Co., Ltd." },
                    { 98, "کانادا", "Allmax Nutrition" },
                    { 99, "آمریکا", "Glanbia Performance Nutrition" },
                    { 100, "بریتانیا", "Maxinutrition" },
                    { 101, "بریتانیا", "Reflex Nutrition" },
                    { 102, "بریتانیا", "Applied Nutrition" },
                    { 103, "بریتانیا", "The Protein Works" },
                    { 104, "بریتانیا", "MaxiNutrition" },
                    { 105, "آفریقای جنوبی", "USN (Ultimate Sports Nutrition)" },
                    { 106, "آمریکا", "NutraBio" },
                    { 107, "آمریکا", "MHP (Maximum Human Performance)" },
                    { 108, "آمریکا", "MusclePharm" },
                    { 109, "آمریکا", "Cellucor" },
                    { 110, "کانادا/آمریکا", "MuscleTech" },
                    { 111, "آمریکا", "NutriBiotic" },
                    { 112, "آمریکا", "Twinlab" },
                    { 113, "بریتانیا", "Vitabiotics" },
                    { 114, "آمریکا", "Nature’s Way" },
                    { 115, "آمریکا", "Solaray" },
                    { 116, "آمریکا", "Swanson Health Products" },
                    { 117, "آمریکا", "NutraKey" },
                    { 118, "آمریکا", "Vital Proteins" },
                    { 119, "آمریکا", "Ancient Nutrition" },
                    { 120, "آمریکا", "Orgain" },
                    { 121, "آمریکا", "Garden of Life" },
                    { 122, "آمریکا", "NutraBio Labs" },
                    { 123, "آمریکا", "RedCon1" },
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

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FullName", "Mobile", "Password" },
                values: new object[,]
                {
                    { 1, "Am@13802", "Amir.azizi1820@gmail.com", "Amir Azizi", "09382530590", "Am@13802" },
                    { 2, "Hu@1801", "Hussein.nakhostin2000@gmail.com", "Hussein Nakhostin", "09376700858", "Hu@13801" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "factories",
                keyColumn: "Id",
                keyValue: 123);

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

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
