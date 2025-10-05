using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class OfferDetailDto
    {
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
