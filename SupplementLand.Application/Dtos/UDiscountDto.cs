using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class UDiscountDto
    {
        [Required]
        public int Id { get; set; }

        [Range(1, 100, ErrorMessage = "Discount must be between 1 and 100 percent")]
        public int Percentage { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CountUsed { get; set; }
    }
}
