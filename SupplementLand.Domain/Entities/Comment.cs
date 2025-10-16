using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required, MaxLength(1000)]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? ParentId { get; set; }
        public Comment? Parent { get; set; }
        public ICollection<Comment>? Children { get; set; }
        [Range(1,5,ErrorMessage ="must be between 1 & 5")]
        public int Rate { get; set; }
    }
}
