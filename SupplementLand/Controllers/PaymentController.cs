using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using SupplementLand.Infrastructure;

namespace SupplementLand.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IZibalService _zibalService;
    private readonly SupplementLandDb _context;
    public PaymentController(SupplementLandDb context,IZibalService zibalService)
    {
        _context=context;
        _zibalService= zibalService;
    }
    [HttpPost("create/{orderId}")]
    public async Task<IActionResult> CreatePayment(int orderId)
    {
        var order = await _context.orders.FindAsync(orderId);
        if (order == null) return NotFound("Order not found");
        if (order.Status != StatusO.NotPaid) return BadRequest("Order already processed");

        string callbackUrl = "https://www.fitozen.ir/api/payment/callback";
        string description = $"پرداخت سفارش شماره {order.Id}";
        long amount = (long)(order.TotalPrice.GetValueOrDefault() * 10); // تومان به ریال

        var result = await _zibalService.CreatePaymentAsync(amount, callbackUrl, description, order.Id.ToString());
        if (result == null || result.result != 100)
            return BadRequest(result?.message ?? "خطا در ایجاد تراکنش");

        order.TrackId = result.trackId;
        await _context.SaveChangesAsync();

        string paymentUrl = $"https://gateway.zibal.ir/start/{result.trackId}";
        return Ok(new { paymentUrl });
    }
    [HttpGet("callback")]
    public async Task<IActionResult> Callback([FromQuery] long trackId, [FromQuery] int success, [FromQuery] int status, [FromQuery] int orderId)
    {
        var order = await _context.orders.FindAsync(orderId);
        if (order == null) return NotFound("Order not found");

        if (success != 1)
        {
            order.Status = StatusO.Canceled;
            await _context.SaveChangesAsync();
            return BadRequest("پرداخت ناموفق بود.");
        }

        var verify = await _zibalService.VerifyPaymentAsync(trackId);
        if (verify == null || verify.result != 100)
        {
            order.Status = StatusO.Canceled;
            await _context.SaveChangesAsync();
            return BadRequest("تأیید پرداخت ناموفق بود.");
        }

        order.Status = StatusO.CheckOut;
        order.OrderDate = DateTime.Now;
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "پرداخت با موفقیت انجام شد.",
            refNumber = verify.refNumber,
            amount = verify.amount,
            cardNumber = verify.cardNumber
        });
    }



}
