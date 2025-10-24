using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public StatusO Status { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public long? TrackId { get; set; }
        public Delivery DeliveryType { get; set; }



    }
    public enum Delivery
    {
        PostPishtaz,
        Snapp
    }
    public enum StatusO
    {
        NotPaid,
        CheckOut,
        Canceled
    }
}
