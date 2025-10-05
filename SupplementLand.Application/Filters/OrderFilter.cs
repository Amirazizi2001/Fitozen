using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Filters
{
    public class OrderFilter:Filter
    {
        public string? Status { get; set; }
        public int? UserId { get; set; }
    }
}
