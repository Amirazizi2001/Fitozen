using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure
{
    public class SupplementLandDb : DbContext
    {
        public SupplementLandDb(DbContextOptions<SupplementLandDb> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Portfolio> portfolios { get; set; }
        public DbSet<Factory> factories { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Rate> rates { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Offer> offers { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<ProductVariant> productVariants { get; set; }
        public DbSet<SupplementFact> supplementFacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           

            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().HasData(
                new User(1, "Amir Azizi", "09382530590", "AQAAAAIAAYagAAAAEFEIAVgtkqrlU0buH3fzJT0aDupPd3d4YpB2OoPs247iNvswidO80jqkhiXhXI5f9w==", "Amir.azizi1820@gmail.com", "Admin")
                {
                    RefreshToken= "o4N0YWnqgI8CqqLqvB+MZfV83gokJj4o7xkNxx5soKk="
                },
                new User(2, "Hussein Nakhostin", "09376700858", "AQAAAAIAAYagAAAAEAB1m2MwA1aqpNTOovEJPwzh/KM2F5QIUja/3RcYUcRGstUyI6BtG2aWQIu9q4UMCw==", "Hussein.nakhostin2000@gmail.com", "Admin")
                {
                    RefreshToken= "v5A3cXc7dpn5f0uDkQmL3ZThmLQXgb7F6t7+07r2iNk="
                }
                );
            modelBuilder.Entity<Factory>().HasData(
        // --- برندهای بین‌المللی ---
        new Factory(1, "Optimum Nutrition (ON)", "آمریکا"),
        new Factory(2, "BSN (Bio-Engineered Supplements & Nutrition)", "آمریکا"),
        new Factory(3, "Cellucor (C4)", "آمریکا"),
        new Factory(4, "MuscleTech", "کانادا/آمریکا"),
        new Factory(5, "Dymatize Nutrition", "آمریکا"),
        new Factory(6, "Universal Nutrition", "آمریکا"),
        new Factory(7, "Animal (Universal Nutrition)", "آمریکا"),
        new Factory(8, "Gaspari Nutrition", "آمریکا"),
        new Factory(9, "Evlution Nutrition (EVL)", "آمریکا"),
        new Factory(10, "MusclePharm", "آمریکا"),
        new Factory(11, "Rule One Proteins", "آمریکا"),
        new Factory(12, "Redcon1", "آمریکا"),
        new Factory(13, "GAT Sport (German American Technologies)", "آمریکا"),
        new Factory(14, "Nutrex Research", "آمریکا"),
        new Factory(15, "ProSupps", "آمریکا"),
        new Factory(16, "ALLMAX Nutrition", "کانادا"),
        new Factory(17, "Kaged Muscle", "آمریکا"),
        new Factory(18, "RSP Nutrition", "آمریکا"),
        new Factory(19, "JYM Supplement Science", "آمریکا"),
        new Factory(20, "Performix", "آمریکا"),
        new Factory(21, "Applied Nutrition", "بریتانیا"),
        new Factory(22, "NOW Foods", "آمریکا"),
        new Factory(23, "GNC", "آمریکا"),
        new Factory(24, "Quest Nutrition", "آمریکا"),
        new Factory(25, "Nature's Best", "آمریکا"),
        new Factory(26, "Sports Research", "آمریکا"),
        new Factory(27, "BPN (Bare Performance Nutrition)", "آمریکا"),
        new Factory(28, "Fixx Nutrition", "استرالیا"),
        new Factory(29, "Huel", "بریتانیا"),
        new Factory(30, "G Fuel", "آمریکا"),
        new Factory(31, "Legion Athletics", "آمریکا"),
        new Factory(32, "1st Phorm", "آمریکا"),
        new Factory(33, "Alani Nu", "آمریکا"),
        new Factory(34, "Alpha Lion", "آمریکا"),
        new Factory(35, "AP Regimen", "آمریکا"),
        new Factory(36, "Axe & Sledge", "آمریکا"),
        new Factory(37, "Barebells", "سوئد"),
        new Factory(38, "Biosteel", "کانادا"),
        new Factory(39, "Built", "آمریکا"),
        new Factory(40, "Ronnie Coleman Signature Series", "آمریکا"),
        new Factory(41, "HealthKart", "هند"),
        new Factory(42, "Sporter.com", "آمریکا"),
        new Factory(43, "Bodybuilding.com", "آمریکا"),
        new Factory(44, "iHerb", "آمریکا"),
        new Factory(45, "Glanbia PLC", "آمریکا"),
        new Factory(46, "Nestlé", "سوئیس"),
        new Factory(47, "Abbott Laboratories", "آمریکا"),
        new Factory(48, "PepsiCo Inc.", "آمریکا"),
        new Factory(49, "Coca-Cola Company", "آمریکا"),
        new Factory(50, "Red Bull GmbH", "اتریش"),
        new Factory(51, "Herbalife", "آمریکا"),
        new Factory(52, "Alticor Inc.", "آمریکا"),
        new Factory(53, "Simply Good Foods Co.", "آمریکا"),
        new Factory(54, "Xiwang Group Co., Ltd", "چین"),
        new Factory(55, "FitLife Brands", "آمریکا"),
        new Factory(56, "Post Holdings", "آمریکا"),
        new Factory(57, "Cizzle Brands Corporation", "آمریکا"),
        new Factory(58, "Mondelez International, Inc.", "آمریکا"),
        new Factory(59, "Jarrow Formulas", "آمریکا"),
        new Factory(60, "Life Extension", "آمریکا"),
        new Factory(61, "Pure Encapsulations", "آمریکا"),
        new Factory(62, "Thorne Research", "آمریکا"),
        new Factory(63, "Designs for Health", "آمریکا"),
        new Factory(64, "NOW Sports", "آمریکا"),
        new Factory(65, "Prozis", "پرتغال"),
        new Factory(66, "Biotech USA", "مجارستان"),
        new Factory(67, "Scitec Nutrition", "مجارستان"),
        new Factory(68, "Extrifit", "چک"),
        new Factory(69, "BigJoy Nutrition", "چک"),
        new Factory(70, "Weider Global Nutrition", "آلمان"),
        new Factory(71, "ESN (Elite Sports Nutrients)", "آلمان"),
        new Factory(72, "FitLine", "آلمان"),
        new Factory(73, "Weider Japan", "ژاپن"),
        new Factory(74, "DNS (Daiwa Nutrition Supplements)", "ژاپن"),
        new Factory(75, "Meiji Co., Ltd.", "ژاپن"),
        new Factory(76, "Orihiro Co., Ltd.", "ژاپن"),
        new Factory(77, "Glanbia Performance Nutrition", "آمریکا"),
        new Factory(78, "Maxinutrition", "بریتانیا"),
        new Factory(79, "Reflex Nutrition", "بریتانیا"),
        new Factory(80, "The Protein Works", "بریتانیا"),
        new Factory(81, "USN (Ultimate Sports Nutrition)", "آفریقای جنوبی"),
        new Factory(82, "NutraBio", "آمریکا"),
        new Factory(83, "MHP (Maximum Human Performance)", "آمریکا"),
        new Factory(84, "NutriBiotic", "آمریکا"),
        new Factory(85, "Twinlab", "آمریکا"),
        new Factory(86, "Vitabiotics", "بریتانیا"),
        new Factory(87, "Nature’s Way", "آمریکا"),
        new Factory(88, "Solaray", "آمریکا"),
        new Factory(89, "Swanson Health Products", "آمریکا"),
        new Factory(90, "NutraKey", "آمریکا"),
        new Factory(91, "Vital Proteins", "آمریکا"),
        new Factory(92, "Ancient Nutrition", "آمریکا"),
        new Factory(93, "Orgain", "آمریکا"),
        new Factory(94, "Garden of Life", "آمریکا"),
        new Factory(95, "Ghost Lifestyle", "آمریکا"),
        new Factory(96, "Primeval Labs", "آمریکا"),
        new Factory(97, "MAN Sports", "آمریکا"),
        new Factory(98, "Isopure", "آمریکا"),
        new Factory(99, "CytoSport (Muscle Milk)", "آمریکا"),
        new Factory(100, "Xtend (Nutrabolt)", "آمریکا"),
        new Factory(101, "Enervit S.p.A.", "ایتالیا"),
        new Factory(102, "Myprotein", "بریتانیا"),
        new Factory(103, "Swisse", "استرالیا"),
        new Factory(104, "Bioriginal", "کانادا"),
        new Factory(105, "H&H Group", "چین"),
        new Factory(106, "Orthomol", "آلمان"),
        new Factory(107, "Doctor’s Best", "آمریکا"),
        new Factory(108, "Source Naturals", "آمریکا"),
        new Factory(109, "AllNutrition", "لهستان"),
        new Factory(110, "MuscleBear", "لهستان"),

        // --- برندهای ایرانی ---
        new Factory(111, "کارن (PNC)", "ایران"),
        new Factory(112, "دوبیس (Dobis Nutrition)", "ایران"),
        new Factory(113, "کاله پرو", "ایران"),
        new Factory(114, "پگاه", "ایران"),
        new Factory(115, "نوتریمد", "ایران"),
        new Factory(116, "اپکس (Apex)", "ایران"),
        new Factory(117, "آلامو", "ایران"),
        new Factory(118, "ابوریحان", "ایران"),
        new Factory(119, "ادوی (Advay)", "ایران"),
        new Factory(120, "لوکس (LOOX)", "ایران"),
        new Factory(121, "های هلث (HiHealth)", "ایران"),
        new Factory(122, "پوراطب", "ایران"),
        new Factory(123, "نوتراکس (Nutrax)", "ایران")

                );
            var categories=new List<Category>();
            // ریشه
            var root = new Category(1, "مکمل‌های ورزشی",null);
            categories.Add(root);

            // ================= 1. پروتئین‌ها =================
            var protein = new Category(2, "پروتئین‌ها", 1);
            categories.Add(protein);

            categories.Add(new Category(3, "وی (Whey)",2));
            categories.Add(new Category(4, "کازئین (Casein)", 2));
            categories.Add(new Category(5, "سویا (Soy)", 2));
            categories.Add(new Category(6, "پروتئین‌های گیاهی", 2));
            categories.Add(new Category(7, "پروتئین تخم‌مرغ / گوشت",2));
            // ================= 2. آمینواسیدها =================
            var amino = new Category(8, "آمینواسیدها", 1);
            categories.Add(amino);

            categories.Add(new Category(9, "BCAA", 8));
            categories.Add(new Category(10, "EAA", 8));
            categories.Add(new Category(11, "گلوتامین", 8));
            categories.Add(new Category(12, "آرژنین", 8));
            categories.Add(new Category(13, "بتاآلانین", 8));
            categories.Add(new Category(14, "کارنیتین", 8));
            // ================= 3. کراتین‌ها =================
            var creatine = new Category(15, "کراتین‌ها", 1);
            categories.Add(creatine);

            categories.Add(new Category(16, "کراتین مونوهیدرات", 15));
            categories.Add(new Category(17, "کراتین HCL", 15));
            categories.Add(new Category(18, "کراتین میکرونایزد", 15));
            categories.Add(new Category(19, "کراتین‌های ترکیبی", 15));
            // ================= 4. گینرها (افزایش وزن) =================
            var gainer = new Category(20, "گینرها (افزایش وزن)", 1);
            categories.Add(gainer);

            categories.Add(new Category(21, "مس گینر", 20));
            categories.Add(new Category(22, "کربو-پروتئین", 20));
            // ================= 5. چربی‌سوزها =================
            var fatBurner = new Category(23, "چربی‌سوزها", 1);
            categories.Add(fatBurner);

            categories.Add(new Category(24, "ترموژنیک", 23));
            categories.Add(new Category(25, "L-Carnitine", 23));
            categories.Add(new Category(26, "CLA", 23));
            categories.Add(new Category(27, "بلوکرهای کربوهیدرات/چربی", 23));
            // ================= 6. انرژی‌زا و پیش‌تمرین =================
            var preWorkout = new Category(28, "مکمل‌های انرژی‌زا و پیش‌تمرین",1);
            categories.Add(preWorkout);

            categories.Add(new Category(29, "پمپ (Nitric Oxide Boosters)",28));
            categories.Add(new Category(30, "کافئین", 28));
            categories.Add(new Category(31, "ترکیبات محرک", 28));
            // ================= 7. ویتامین‌ها و مواد معدنی =================
            var vitamins = new Category(32, "ویتامین‌ها و مواد معدنی",1);
            categories.Add(vitamins);

            categories.Add(new Category(33, "مولتی‌ویتامین", 32));
            categories.Add(new Category(34, "ویتامین D", 32));
            categories.Add(new Category(35, "ویتامین C", 32));
            categories.Add(new Category(36, "ویتامین‌های گروه B", 32));
            categories.Add(new Category(37, "کلسیم", 32));
            categories.Add(new Category(38, "منیزیم", 32));
            categories.Add(new Category(39, "روی (Zinc)", 32));
            // ================= 8. اسیدهای چرب ضروری =================
            var efa = new Category(40, "اسیدهای چرب ضروری",1);
            categories.Add(efa);

            categories.Add(new Category(41, "امگا 3", 40));
            categories.Add(new Category(42, "امگا 6", 40));
            categories.Add(new Category(43, "امگا 9", 40));
            // ================= 9. ریکاوری و مفاصل =================
            var recovery = new Category(44, "مکمل‌های ریکاوری و سلامت مفاصل", 1);
            categories.Add(recovery);

            categories.Add(new Category(45, "گلوکوزامین", 44));
            categories.Add(new Category(46, "کندرویتین", 44));
            categories.Add(new Category(47, "MSM", 44));
            // ================= 10. هورمونی =================
            var hormonal = new Category(48, "مکمل‌های هورمونی", 1);
            categories.Add(hormonal);

            categories.Add(new Category(49, "بوستر تستوسترون", 48));
            categories.Add(new Category(50, "مهارکننده‌های استروژن",48));
            categories.Add(new Category(51, "ZMA", 48));
            // ================= 11. ترکیبی و تخصصی =================
            var complex = new Category(52, "مکمل‌های ترکیبی و تخصصی", 1);
            categories.Add(complex);

            categories.Add(new Category(53, "پیش‌ورزش (Pre-Workout)", 52));
            categories.Add(new Category(54, "پس‌از‌ورزش (Post-Workout)", 52));
            categories.Add(new Category(55, "مولتی بلِند پروتئین", 52));
            // ================= 12.نوشیدنی‌ها و ژل‌ها =================
            var drinks = new Category(56, "نوشیدنی‌ها و ژل‌های ورزشی", 1);
            categories.Add(drinks);

            categories.Add(new Category(57, "ایزوتونیک", 56));
            categories.Add(new Category(58, "ژل انرژی", 56));
            categories.Add(new Category(59, "نوشیدنی‌های پروتئینی آماده", 56)); 


            modelBuilder.Entity<Category>().HasData(
             categories
                );
        }
    }
}
