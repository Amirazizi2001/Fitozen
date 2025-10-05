using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }

        [Required]
        [MaxLength(11)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    public class UserProfileDto
    {
        public int Id { get; set; }              
        public string FullName { get; set; }     
        public string Email { get; set; }        
        public string Phone { get; set; }        
        public DateTime? BirthDate { get; set; } 
    }

}
