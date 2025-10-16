using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services;

public class CatService : ICatService
{
    private readonly SupplementLandDb _context;
    public CatService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddCategory(CatDto catDto)
    {
        var cat = new Category
        {
            Name = catDto.Name,
            ParentId = catDto.ParentId
        };

        try
        {
            await _context.categories.AddAsync(cat);
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Category added successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = ex.Message };
        }
    }

    public async Task<OperationResult> UpdateCategory(CUpdateDto cUpdateDto)
    {
        var existingCat = await GetCategoryById(cUpdateDto.Id);
        if (existingCat == null)
            return new OperationResult { Success = false, Message = "Category not found" };

        existingCat.Name = cUpdateDto.Name;
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Category updated successfully" };
    }

    public async Task<OperationResult> DeleteCategory(int id)
    {
        var cat = await GetCategoryById(id);
        if (cat == null)
            return new OperationResult { Success = false, Message = "Category not found" };

        _context.categories.Remove(cat);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Category deleted successfully" };
    }

    

    public async Task<Category> GetCategoryById(int id)
        => await _context.categories.FindAsync(id);

    public async Task<DataResult<CatListDto>> GetChildrenCategories(CategoryFilter filter)
    {
        IQueryable<Category> query = _context.categories.AsQueryable();

        if (filter.ParentId != null)
            query = query.Where(c => c.ParentId == filter.ParentId);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(c => new CatListDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId,
                ParentCat = c.Parent != null ? c.Parent.Name : null
            })
            .ToListAsync();

        return new DataResult<CatListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<DataResult<PListDto>> GetCatProducts(CategoryFilter filter)
    {
        IQueryable<Product> query = _context.products.AsQueryable();

        if (filter.CategoryName!=null)
            query = query.Where(p => p.Category.Name.Contains(filter.CategoryName));

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(p => new PListDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ProDate = p.ProDate,
                ExpDate = p.ExpDate,
                Stock = p.Stock,
                Weight = p.Weight,
               
                Size = p.Size,
               
                
               
                CategoryId = p.CategoryId,
                FactoryId = p.FactoryId,
                Category = p.Category.Name,
                Factory = p.Factory.Name
            }).AsNoTracking()
            .ToListAsync();

        return new DataResult<PListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<IEnumerable<CategoryListDto>> GetCategories()
    {
        var all = await _context.categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Name,
                c.ParentId
            })
            .ToListAsync();

        // توجه: ParentId ممکنه nullable باشه
        var lookup = all.ToLookup(x => x.ParentId);

        List<CategoryListDto> BuildTree(int? parentId)
        {
            return lookup[parentId]
               .Select(c =>
               {
                   var childern = BuildTree(c.Id);
                   return new CategoryListDto
                   {
                       Id = c.Id,
                       Name = c.Name,
                       Childern = childern.Any() ? childern : null,
                   };
               }).ToList();
                
        }

        // ریشه‌ها
        return BuildTree(null);
    }




}
