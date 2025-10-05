using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class UPackageDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public List<int> ProductIds { get; set; } = new List<int>();

        public int? DiscountId { get; set; }
    }
}
