using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class DiscountListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal? Percentage { get; set; }
        public string? ProductName { get; set; }
        public string? PackageName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CountUse { get; set; }
    }
}
