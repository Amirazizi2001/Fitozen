using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class ComListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
        [Required, MaxLength(1000)]
        public string Content { get; set; }
        public int Rate { get; set; }
    }
}
