using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Package
    {
        public Package()
        {
            Products=new List<Product>();
        }
        
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        public decimal? TotalPrice { get; set; }
        public ICollection<Product> Products { get; set; }
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
        
        
    }
}
