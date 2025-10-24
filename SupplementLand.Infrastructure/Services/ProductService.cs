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
            Warning = dto.Warning,
            Size = dto.Size,
            Goals = string.Join("", dto.Goals),
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
        if (!string.IsNullOrEmpty(filter.Category))
            query = query.Where(p => p.Category.Name.Contains(filter.Category));
        if (!string.IsNullOrEmpty(filter.Category))
            query = query.Where(p => p.Factory.Name.Contains(filter.Factory));

        if (filter.CategoryId != null)
            query = query.Where(p => p.CategoryId == filter.CategoryId);

        if (filter.FactoryId != null)
            query = query.Where(p => p.FactoryId == filter.FactoryId);
        if (filter.MinPrice != null)
            query = query.Where(p => p.Price >= filter.MinPrice);
        if (filter.MaxPrice != null)
            query = query.Where(p => p.Price <= filter.MaxPrice);

        var totalCount = await query.CountAsync();

        var items = await query.Select(p => new ProductListsDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Factory = p.Factory.Name,
            Category = p.Category.Name,
            DocumentIds = p.Documents.Select(p => p.Id).ToList()

        })
        .Skip((filter.Page - 1) * filter.PageSize)
        .Take(filter.PageSize).AsNoTracking()
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
        product.Warning = dto.Warning;
        product.ProDate = dto.ProDate;
        product.ExpDate = dto.ExpDate;
        product.Goals = string.Join(",", dto.Goals);
        product.DiscountId = dto.DiscountId;
        product.Weight = dto.Weight;
        product.Size = dto.Size;

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Product updated successfully" };
    }

    public async Task<OperationResult> DeleteProduct(int id)
    {
        var product = await _context.products.FindAsync(id);
        if (product == null) return new OperationResult { Success = false, Message = "Product not found" };
        var supplementFacts = _context.supplementFacts.Where(sp => sp.ProductId == product.Id).ToList();
        var variants = _context.productVariants.Where(pv => pv.ProductId == product.Id).ToList();
        var documents = _context.documents.Where(d => d.ProductId == product.Id).ToList();
        _context.supplementFacts.RemoveRange(supplementFacts);
        _context.productVariants.RemoveRange(variants);
        _context.documents.RemoveRange(documents);


        _context.products.Remove(product);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Product deleted successfully" };
    }




    // 🔹 ثبت نظر روی پیشنهاد ویژه


    public async Task<DataResult<ComListDto>> GetProductComments(CommentFilter filter)
    {
        IQueryable<Comment> query = _context.comments.Include(c => c.Product).Include(c => c.User).AsQueryable();
        if (filter.ProductName != null)
        {
            query = query.Where(c => c.Product.Name.Contains(filter.ProductName));
        }
        var totalCount = await query.CountAsync();
        var items = await query.OrderByDescending(c => c.CreateDate).Select(c => new ComListDto
        {
            Id = c.Id,
            UserId = c.UserId,
            Content = c.Content,
            CreateDate = c.CreateDate,
            Rate = c.Rate,
            FullName = c.User.FullName,
            ProductName = c.Product.Name,
            ParentId = c.ParentId,


        }).Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).AsNoTracking().ToListAsync();
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
            .Include(p => p.Rates).
            Include(p => p.Documents)
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
            ProDate = product.ProDate,
            CategoryId = product.CategoryId,
            FcatoryId = product.FactoryId,
            DiscountId = product.DiscountId,
            ExpDate = product.ExpDate,
            Size = product.Size,
            Weight = product.Weight,
            Goals = product.Goals.Split(",").ToList(),


            DocumentIds = product.Documents?.Select(p => p.Id).ToList() ?? new List<Guid>()
            ,

            SupplementFacts = (product.supplementFacts ?? new List<SupplementFact>())
                .Select(s => new SupplementsFactDto { Id = s.id, Label = s.Label, Value = s.Facts })
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
                    DocumentIds = r.DocumentIds
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
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            DocumentIds = p.Documents.Where(d => d.IsDefault).Select(d => d.Id).ToList(),
        }).AsNoTracking().ToListAsync();
        return products;

    }
    public async Task<IEnumerable<NewProductListDto>> GetBestSellers()
    {
        var bestSellers = await _context.portfolioItems
            .Include(pi => pi.Product).ThenInclude(p => p.Documents)
            .GroupBy(pi => new { pi.ProductId, pi.Product.Name, pi.Product.Price })
            .Select(g => new
            {
                g.Key.ProductId,
                g.Key.Name,
                g.Key.Price,
                Documents = g.SelectMany(x => x.Product.Documents)
                             .Where(d => d.IsDefault)
                             .Select(d => d.Id)
                             .ToList(),
                TotalSold = g.Sum(x => x.Quantity)
            })
            .OrderByDescending(g => g.TotalSold)
            .Take(4)
            .AsNoTracking()
            .ToListAsync();

        var result = bestSellers.Select(b => new NewProductListDto
        {
            Id = b.ProductId,
            Name = b.Name,
            Price = b.Price,
            DocumentIds = b.Documents
        }).ToList();

        return result;
    }


    public async Task<OperationResult> DeleteVariant(int id)
    {
        var variant = await _context.productVariants.FirstOrDefaultAsync(pv => pv.Id == id);
        if (variant == null) { return new OperationResult { Success = false, Message = "Variant not found" }; }
        _context.productVariants.Remove(variant);
        _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "variant deleted successfully" };
    }

    public async Task<OperationResult> DeleteSupplementFacts(int id)
    {
        var supplefact = await _context.supplementFacts.FirstOrDefaultAsync(sf => sf.id == id);
        if (supplefact == null) { return new OperationResult { Success = false, Message = "not found" }; }
        _context.supplementFacts.Remove(supplefact);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "deleted successfully" };
    }

    public async Task<OperationResult> ApplyProductDiscount(string code, int productId)
    {
        var discount = await _context.discounts.FirstOrDefaultAsync(d => d.Code == code);
        if (discount == null) { return new OperationResult { Success = false, Message = "This code doesn't exist" }; }
        var percentage = discount.Percentage;
        var product = await _context.products.FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null || product.DiscountId != discount.Id) { return new OperationResult { Success = false, Message = "this code isn't for this product or product doesn't exist" }; }
        var price = product.Price;
       
        decimal newPrice = price - ((price * percentage) / 100);
        

        if (discount.EndDate <= DateTime.UtcNow)
        {
            product.Price = newPrice;
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "discount applied" };
        }
        return new OperationResult { Success = false, Message = "discount ended" };


    }
}


