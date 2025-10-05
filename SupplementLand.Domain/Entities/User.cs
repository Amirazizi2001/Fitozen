using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities;

public class User
{
    public User(int id, string fullName, string mobile,
        string password, string email, string role)
    {
        Id = id;
        FullName = fullName;
        Mobile = mobile;
        Password = password;
        
        Email = email;
        Role = role;
       


    }
    public User()
    {

    }


    public int Id { get; set; }
    public string FullName { get; set; }

    [Required]
    [MaxLength(11)]
    public string Mobile { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } // هش شده
    [EmailAddress]
    public string Email { get; set; }
    public string Role { get; set; } = "Customer";
    public DateTime? BirthDate { get; set; }

    // برای JWT RefreshToken
    public string? RefreshToken { get; set; } = GenerateRefreshToken();
    public DateTime? RefreshTokenExpiryTime { get; set; }

    // Navigation
    public ICollection<Portfolio> Portfolio { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Rate> Rates { get; set; }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
 



