using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Filters
{
    public class CategoryFilter:Filter
    {
        public string? CategoryName { get; set; }
        public int? ParentId { get; set; }
    }
}
