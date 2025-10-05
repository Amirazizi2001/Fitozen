using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface IOfferService
    {
        Task<OperationResult> AddOffer(OfferDto dto);
        Task<OperationResult> UpdateOffer(UOfferDto dto);
        Task<OperationResult> DeleteOffer(int id);
        Task<Offer> GetOfferById(int id);
        Task<DataResult<OffersDto>> GetSpecialOffers(Filter filter);
        Task<OperationResult> AddOfferComment(int productId,CommentDto dto);
        Task<OfferDetailDto> GetOfferDetail(int id);
    }
}
