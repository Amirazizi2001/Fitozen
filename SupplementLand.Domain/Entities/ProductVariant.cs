using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities;

public class ProductVariant
{
    public int Id { get; set; }

    
    public int ProductId { get; set; }
    public Product Product { get; set; }

    
    public string? VariantName { get; set; }  
    public int? Serving { get; set; }         
     
    public decimal? Price { get; set; }     
    public int? Stock { get; set; }
}
