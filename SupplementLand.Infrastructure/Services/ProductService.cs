using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using SupplementLand.Infrastructure.Filters;

namespace SupplementLand.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly SupplementLandDb _context;

    public ProductService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddProduct(ProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            FactoryId = dto.FactoryId,
            Stock = dto.Stock,
           Warning= dto.Warning,
        };

        await _context.products.AddAsync(product);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Product added successfully" };
    }

    public async Task<DataResult<ProductListsDto>> GetProducts(ProductFilter filter)
    {
        IQueryable<Product> query = _context.products
            .Include(p => p.Category)
            .Include(p => p.Factory);

        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(p => p.Name.Contains(filter.Name));

        if (filter.CategoryId != null)
            query = query.Where(p => p.CategoryId == filter.CategoryId);

        if (filter.FactoryId != null)
            query = query.Where(p => p.FactoryId == filter.FactoryId);

        var totalCount = await query.CountAsync();

        var items = await query.Select(p => new ProductListsDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Factory = p.Factory.Name,
            Category = p.Category.Name,
            DocumentIds=p.Documents.Select(p=>p.Id).ToList()

        })
        .Skip((filter.Page - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .ToListAsync();

        return new DataResult<ProductListsDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<OperationResult> UpdateProduct(PUpdateDto dto)
    {
        var product = await _context.products.FindAsync(dto.Id);
        if (product == null) return new OperationResult { Success = false, Message = "Product not found" };

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;
        product.FactoryId = dto.FactoryId;
        product.Stock = dto.Stock;
        product.Warning=dto.Warning;

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Product updated successfully" };
    }

    public async Task<OperationResult> DeleteProduct(int id)
    {
        var product = await _context.products.FindAsync(id);
        if (product == null) return new OperationResult { Success = false, Message = "Product not found" };

        _context.products.Remove(product);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Product deleted successfully" };
    }


    

    // 🔹 ثبت نظر روی پیشنهاد ویژه
   

    public async Task<DataResult<ComListDto>> GetProductComments(CommentFilter filter)
    {
        IQueryable<Comment> query = _context.comments.Include(c=>c.Product).Include(c=>c.User).AsQueryable();
        if (filter.ProductName != null)
        {
            query = query.Where(c => c.Product.Name.Contains(filter.ProductName));
        }
        var totalCount = await query.CountAsync();
        var items = await query.OrderByDescending(c=>c.CreateDate).Select(c => new ComListDto
        {
            Id = c.Id,
            UserId = c.UserId,
            Content = c.Content,
            CreateDate = c.CreateDate,
            Rate = c.Rate,
            FullName = c.User.FullName,
            

        }).Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        return new DataResult<ComListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
    public async Task<ProductDetailDto> GetProductDetail(int productId)
    {
        var product = await _context.products
            .Include(p => p.Category)
            .Include(p => p.Factory)
            .Include(p => p.Discount)
            .Include(p => p.RelatedProducts)
            .Include(p => p.Comments)
                .ThenInclude(c => c.User)
            .Include(p => p.supplementFacts)
            .Include(p => p.ProductVariants)
            .Include(p => p.Rates)
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
            return null;

        return new ProductDetailDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryName = product.Category?.Name,
            FactoryName = product.Factory?.Name,
            Warning = product.Warning,
            DocumentIds=product.Documents.Select(p=>p.Id).ToList()
            ,

            SupplementFacts = (product.supplementFacts ?? new List<SupplementFact>())
                .Select(s => new SupplementFactDto { Label = s.Label, Value = s.Facts })
                .ToList(),

            Variants = (product.ProductVariants ?? new List<ProductVariant>())
                .Select(pv => new ProductVariantDto
                {
                    Id = pv.Id,
                    Name = pv.VariantName,
                    Servings = pv.Serving,
                    Stock = pv.Stock,
                    Price = pv.Price
                }).ToList(),

            Rating = (product.Rates?.Any() == true) ? product.Rates.Average(r => r.Score) : 0,

            Related = (product.RelatedProducts ?? new List<RelatedProduct>())
                .Select(r => new RelatedProductDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Price = r.Price,
                    DocumentIds=r.DocumentIds
                }).ToList(),

            Comments = (product.Comments ?? new List<Comment>())
                .Select(c => new ComListDto
                {
                    Id = c.Id,
                    FullName = c.User?.FullName,
                    UserId = c.UserId,
                    Content = c.Content,
                    Rate = c.Rate,
                    CreateDate = c.CreateDate
                }).ToList()
        };
    }


    

    public async Task<Product> GetProductById(int id)
    {
        return await _context.products.FindAsync(id);
    }

    public async Task<OperationResult> AddProductVariant(ProductsVariantDto dto)
    {
        var product = new ProductVariant()
        {
            //Id = dto.Id,
            Price = dto.Price,
            Stock = dto.Stock,
            Serving = dto.Servings,
            VariantName = dto.Name,
            ProductId = dto.ProductId

        };
        await _context.productVariants.AddAsync(product);
        try
        {
            
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Product Variant Added successfully" };

        }
        catch
        {
            return new OperationResult { Success = false, Message = "an error occurd" };
        }
    }

    public async Task<OperationResult> AddSupplementFact(SupplementFactsDto dto)
    {
        var product = new SupplementFact()
        {
            Label = dto.Label,
            Facts = dto.Value,
            ProductId = dto.ProductId,

        };
        await _context.supplementFacts.AddAsync(product);
        try
        {
            await _context.SaveChangesAsync();
            return new OperationResult
            {
                Success = true,
                Message = "Added successfully"
            };
        }
        catch
        {
            return new OperationResult { Success = false, Message = "an error occured" };
        }
    }

    public async Task<IEnumerable<NewProductListDto>> GetNewProductList()
    {
        var products = await _context.products.OrderByDescending(p => p.Id).Take(4).Select(p => new NewProductListDto
        {
            Name = p.Name,
            Price = p.Price,
        }).ToListAsync();
        return products;
        
    }
    public async Task<IEnumerable<NewProductListDto>> GetBestSellers()
    {
        var bestSellers = await _context.portfolioItems
            .Include(pi => pi.Product)
            .GroupBy(pi => new { pi.ProductId, pi.Product.Name, pi.Product.Price })
            .Select(g => new
            {
                g.Key.ProductId,
                g.Key.Name,
                g.Key.Price,
                TotalSold = g.Sum(x => x.Quantity)
            })
            .OrderByDescending(g => g.TotalSold)
            .Take(4)
            .Select(g => new NewProductListDto
            {
                Name = g.Name,
                Price = g.Price
            })
            .ToListAsync();

        return bestSellers;
    }

}


