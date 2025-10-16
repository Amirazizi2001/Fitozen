using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos;

public class PoListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public string Mobile { get; set; }
    public string FullName { get; set; }
    public string status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
}
public class PortListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public string Mobile { get; set; }
    public string FullName { get; set; }
    public string status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public IEnumerable<PIListDto>? PortfolioItemsList {  get; set; }
}

