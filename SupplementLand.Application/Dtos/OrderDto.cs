using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class OrderDto
    {
        public int PortfolioId { get; set; }
        public DateTime OrderDate { get; set; }
        public StatusO Status { get; set; }
     
        public int UserId { get; set; }
    }
}
