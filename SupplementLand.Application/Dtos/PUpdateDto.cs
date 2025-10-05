using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class PUpdateDto
    {
        public  int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ProDate { get; set; }
        public DateTime ExpDate { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
       
        [MaxLength(60)]
        public string Size { get; set; }
        public int CatId { get; set; }
        public int FacId { get; set; }
        public int? DiscountId { get; set; }
        public string Description { get; set; }
        public List<string> Goals { get; set; }
        public int CategoryId { get; set; }
        public int FactoryId { get; set; }
        public string  Warning { get; set; }
    }
}
