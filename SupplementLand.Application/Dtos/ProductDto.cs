using SupplementLand.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SupplementLand.Application.Dtos;

public class ProductDto
{
    [MaxLength(60)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime ProDate { get; set; }
    public DateTime ExpDate { get; set; }
    public int Stock { get; set; }
    public decimal Weight { get; set; }
    
    [MaxLength(300)]
    public string? Description { get; set; }
    [MaxLength(60)]
    public string? Size { get; set; }
    public string? Warning { get; set; }

   
    public int CategoryId { get; set; }
    public int FactoryId { get; set; }
    public int? DiscountId { get; set; }
    public List<string> Goals { get; set; }
}

public class ProductsVariantDto
{
   // public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public int? Servings { get; set; }
    public int? ProductId { get; set; }
}
public class ProductVariantDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public int? Servings { get; set; }
}

public class SupplementFactsDto
{
    public int ProductId { get; set; }
    public string Label { get; set; }
    public string Value { get; set; }
}
public class SupplementFactDto
{
    public string Label { get; set; }
    public string Value { get; set; }
}
public class SupplementsFactDto
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string Value { get; set; }
}
public class RelatedProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<Guid>? DocumentIds { get; set; }
}
public class OrderProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal? DisCount { get; set; }
    public ProductsVariantDto? Variant { get; set; }

}

public class ProductDetailDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
   
    public int? Stock { get; set; }
    public decimal? Price { get; set; }
    public decimal? OldPrice { get; set; }
    public double? Rating { get; set; }
    public string? Description { get; set; }
    public string? CategoryName { get; set; }
    public string? Warning { get; set; }

    public string? FactoryName { get; set; }
    public List<Guid>? DocumentIds { get; set; }
    public List<ProductVariantDto>? Variants { get; set; }
    public List<SupplementsFactDto>? SupplementFacts { get; set; }
    public int FcatoryId { get; set; }
    public int CategoryId { get; set; }
    public int? DiscountId{ get; set; }
    public decimal Weight { get; set; }
    public List<RelatedProductDto>? Related { get; set; }
    public List<ComListDto>? Comments { get; set; }
    public DateTime ProDate { get; set; }
    public DateTime ExpDate { get; set; }
    public string Size { get; set; }
    public List<string> Goals { get; set; }



}
