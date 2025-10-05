using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class PListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ProDate { get; set; }
        public DateTime ExpDate { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public string ProductForm { get; set; }
        public string Size { get; set; }
        public string Efficiency { get; set; }
        public string AgeCategory { get; set; }
        public string Taste { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int FactoryId { get; set; }
        public string Factory { get; set; }
        public int? DiscountId { get; set; }
        public List<string> Goals { get; set; }
    }
}

