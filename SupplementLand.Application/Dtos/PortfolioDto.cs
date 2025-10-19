using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class PortfolioDto
    {
        public string Name { get; set; }
       
        public Status status { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        
    }

}
