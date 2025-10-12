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

public class OfferService:IOfferService
{
    private readonly SupplementLandDb _context;

    public OfferService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddOffer(OfferDto dto)
    {
        try
        {
            var offer = new Offer
            {
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ProductId = dto.ProductId,
                PackageId = dto.PackageId
            };

            await _context.offers.AddAsync(offer);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message="Offer added successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success=false,Message= "Error adding offer"};
            }
    }

    public async Task<OperationResult> UpdateOffer(UOfferDto dto)
    {
        var offer = await GetOfferById(dto.Id);
        if (offer == null)
            return new OperationResult { Success = false, Message = "Offer not found" };

        offer.Title = dto.Title;
        offer.Description = dto.Description;
        offer.StartDate = dto.StartDate;
        offer.EndDate = dto.EndDate;
        offer.ProductId = dto.ProductId;
        offer.PackageId = dto.PackageId;

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Offer updated successfully" };
    }

    public async Task<OperationResult> DeleteOffer(int id)
    {
        var offer = await GetOfferById(id);
        if (offer == null)
            return new OperationResult { Success = false, Message = "Offer not found" } ;

        _context.offers.Remove(offer);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Offer deleted successfully" };
    }

    public async Task<Offer> GetOfferById(int id)
    {
        return await _context.offers.FindAsync(id);
    }

    
        public async Task<DataResult<OffersDto>> GetSpecialOffers(Filter filter)
    {
        IQueryable<Product> query=_context.products.AsQueryable();
        query = query.Where(p => p.DiscountId != null);

        var totalCount = await query.CountAsync();
        var items = await query.Select(product => new OffersDto
        {
            Id = product.Id,
            Name = product.Name,
            OriginalPrice = product.Price,
            Stock = product.Stock,

            Related = product.RelatedProducts.Select(r => new RelatedProductDto
            {
                Id = r.Id,
                Name = r.Name,
                Price = r.Price,
                DocumentIds=r.DocumentIds
            }).ToList()
        }).Skip((filter.Page - 1) * filter.PageSize).ToListAsync();
        
            

        
       

        return new DataResult<OffersDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<OperationResult> AddOfferComment(int productId, CommentDto dto)
    {
        var comment = new Comment
        {
            ProductId = productId,
            Content = dto.Content,
            UserId = dto.UserId,
            CreateDate = DateTime.Now,
            Rate = dto.Rate
        };

        await _context.comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Comment added successfully" };
    }

    public async Task<OfferDetailDto> GetOfferDetail(int id)
    {
        var offer=await _context.offers.Include(o=>o.Product).SingleOrDefaultAsync(o=>o.Id == id);
        return new OfferDetailDto
        {
            Title=offer.Title,
            Description=offer.Description,
            DiscountedPrice=offer.DiscountedPrice,
            EndDate=offer.EndDate,
            StartDate=offer.StartDate,
            ProductId=offer.ProductId,
            ProductName=offer.Product.Name
        };
    }
}

