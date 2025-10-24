using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces;

public interface IZibalService
{
    Task<ZibalRequestResponse?> CreatePaymentAsync(long amount, string callbackUrl, string description, string orderId);
    Task<ZibalVerifyResponse?> VerifyPaymentAsync(long trackId);
    Task<string> InquiryAsync(long trackId);
}
