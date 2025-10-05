using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PortfolioItem> PortfolioItems { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Status status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Order Order { get; set; }

    }
    public enum Status
    {
        Opened,
        Checkout,
        cancelled
    }
}
