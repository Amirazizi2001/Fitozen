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
        public DbSet<Document> documents { get; set; }

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
