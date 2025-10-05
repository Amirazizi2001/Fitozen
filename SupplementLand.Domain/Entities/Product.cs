using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ProDate { get; set; }
        public DateTime ExpDate { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        
        [MaxLength(60)]
        public string Size { get; set; }
        [MaxLength(300)]
        public string  Description { get; set; }
        [MaxLength(100)]
        public string Warning { get; set; }


        public string Goals { get; set; }
        public ICollection<PortfolioItem> PortfolioItems { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Package> Packages { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<RelatedProduct>? RelatedProducts { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public ICollection<ProductVariant>? ProductVariants { get; set; }
        public ICollection<SupplementFact>? supplementFacts { get; set; }

    }
    
    
}
