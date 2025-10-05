using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "Mobile is essential")]
        [MaxLength(11)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Password is essential")]
        [StringLength(12, ErrorMessage = "2 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        [Compare("Password", ErrorMessage = "Please repeat the password correct")]
        public string ConfirmPassword { get; set; }
    }
}
