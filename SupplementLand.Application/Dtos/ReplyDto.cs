using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class ReplyDto
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Reply message is required")]
        [MaxLength(2000, ErrorMessage = "Reply cannot exceed 2000 characters")]
        public string Reply { get; set; }
    }
}
