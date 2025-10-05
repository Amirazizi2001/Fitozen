using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public StatusO Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string PortfolioName { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }    
        public decimal TotalPrice { get; set; }     
        public int Quantity { get; set; }
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
