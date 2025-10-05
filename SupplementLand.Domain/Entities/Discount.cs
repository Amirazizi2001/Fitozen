using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        [Range(1,100,ErrorMessage ="Use between number 1,100")]
        public int? Percentage { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Product? Product { get; set; }
        public Package? Package { get; set; }

    }
}
