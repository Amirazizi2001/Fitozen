using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class ProductsListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rate { get; set; }
        public string Factory { get; set; }
        public string Category { get; set; }
       
        public List<string>? Goals { get; set; }
    }
    public class ProductListsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Factory { get; set; }
        public string Category { get; set; }
        public int Stock {  get; set; }
        public string ImageUrl { get; set; }
    }
}
