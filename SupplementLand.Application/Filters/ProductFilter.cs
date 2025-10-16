using SupplementLand.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Filters
{
    public class ProductFilter:Filter
    {
        public string? Category { get; set; }
        public string? Factory { get; set; }
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? FactoryId { get; set; }

    }
}
