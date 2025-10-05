using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Goal
    {
        
        public int Id { get; set; }
        [MaxLength(100)]
        public string Text { get; set; }

        // رابطه با محصول
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
