using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos;

public class DiscountDto
{

    [Required]
    public string Title { get; set; }

    [Required]
    public string Code { get; set; }

    [Range(1, 100, ErrorMessage = "Discount must be between 1 and 100 percent")]
    public int Percentage { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public decimal? DiscountedPrice { get; set; }


}
