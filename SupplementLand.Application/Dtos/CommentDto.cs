using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class CommentDto
    {
        public int UserId { get; set; }
        [Required, MaxLength(1000)]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public int Rate { get; set; }
    }
    public class CommentsDto
    {
       
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
    }
}
