using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Mobile is essential")]
        [MaxLength(11)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Password is essential")]
        [StringLength(12, ErrorMessage = "2 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
