using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class SupplementFact
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Label { get; set; }
        public  string Facts { get; set; }
    }
}
