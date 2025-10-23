using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities;

public class PortfolioItem
{
    public int Id { get; set; }
    public int PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int? VariantId { get; set; }
    public int Quantity { get; set; }
}
