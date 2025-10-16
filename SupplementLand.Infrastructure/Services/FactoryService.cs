using Azure.Core;
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

public class FactoryService : IFactoryService
{
    private readonly SupplementLandDb _context;
    public FactoryService(SupplementLandDb context)
    {
        _context = context;
    }
    public async Task<OperationResult> AddFactory(FacDto facDto)
    {
        var factory = new Factory
        {
            Name = facDto.Name,
            Country = facDto.Country
        };

        try
        {
            await _context.factories.AddAsync(factory);
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "added successfully" };
        }
        catch
        {
            return new OperationResult { Success = false, Message = "an error occured" };
        }
    }
    public async Task<OperationResult> UpdateFactory(FUpdateDto fUpdateDto)
    {
        var factory = await _context.factories.FindAsync(fUpdateDto.Id);
        if (factory == null)
            return new OperationResult { Success = false, Message = "Factory not found" };

        factory.Name = fUpdateDto.Name;
        factory.Country = fUpdateDto.Country;

        try
        {
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Updated successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = "an error occured" };
        }
    }
    public async Task<OperationResult> DeleteFactory(int id)
    {
        var factory = await _context.factories.FindAsync(id);
        if (factory == null)
            return new OperationResult { Success = false, Message = "not found" };


        _context.factories.Remove(factory);
        try
        {
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Deleted successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = "an error occured" };
        }
    }

    public async Task<DataResult<Factory>> GetAllFactories(Filter filter)
    {
        IQueryable<Factory> query = _context.factories.AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).AsNoTracking().ToListAsync();
        return new DataResult<Factory>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

   

    public async Task<DataResult<PListDto>> GetFactoryProducts(FactoryFilter filter)
    {
        IQueryable<Product> query = _context.products.Include(p=>p.Factory).AsQueryable();
        if (filter.FactoryName != null)
        {
            query = query.Where(p => p.Factory.Name.Contains( filter.FactoryName));
        }
        var totalCount = await query.CountAsync();
        var items = await query.Select(p => new PListDto
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
        }).Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).AsNoTracking().ToListAsync();
        return new DataResult<PListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
    public async Task<DataResult<FacListDto>> GetFactoriesList(Filter filter)
    {
        IQueryable<Factory> query = _context.factories.AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Select(f => new FacListDto
        {
            Id = f.Id,
            Name = f.Name,
            DocumentIds=f.Documents.Select(f=>f.Id).ToList(),
            

            
        }).Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).AsNoTracking().ToListAsync();
        return new DataResult<FacListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize

        };
    }
    public async Task<DataResult<ProductListDto>> GetFactoryProductsList(FactoryFilter filter)
    {
        IQueryable<Product> query=_context.products.AsQueryable();
        if(filter.FactoryName!=null)
        {
            query=query.Where(p=>p.Factory.Name.Contains(filter.FactoryName));
        }
        var totalCount= await query.CountAsync();
        var items=await query.Select(p=>new ProductListDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            FactoryId=p.FactoryId,
            DocumentIds =p.Documents.Select(p=>p.Id).ToList(),
        }).Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).AsNoTracking().ToListAsync();
        return new DataResult<ProductListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize

        };
    }

    public async Task<Factory> GetFactoryById(int id)
    {
        return await _context.factories.FindAsync(id);
    }

    
}
