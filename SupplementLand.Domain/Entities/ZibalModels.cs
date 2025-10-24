using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities;

// مدل ارسال درخواست پرداخت
public class ZibalRequestDto
{
    public string merchant { get; set; }
    public long amount { get; set; }
    public string callbackUrl { get; set; }
    public string description { get; set; }
    public string orderId { get; set; }
    public string mobile { get; set; }
}

// پاسخ زیبال به درخواست پرداخت
public class ZibalRequestResponse
{
    public int result { get; set; }
    public string message { get; set; }
    public long trackId { get; set; }
}

// مدل درخواست برای Verify
public class ZibalVerifyRequest
{
    public string merchant { get; set; }
    public long trackId { get; set; }
}

// پاسخ Verify
public class ZibalVerifyResponse
{
    public int result { get; set; }
    public string message { get; set; }
    public string paidAt { get; set; }
    public string cardNumber { get; set; }
    public int status { get; set; }
    public long amount { get; set; }
    public string refNumber { get; set; }
    public string description { get; set; }
    public string orderId { get; set; }
}
