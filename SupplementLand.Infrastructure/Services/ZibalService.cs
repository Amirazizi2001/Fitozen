using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace SupplementLand.Infrastructure.Services;
public class ZibalService : IZibalService
{
    private readonly HttpClient _http;
    private const string BaseUrl = "https://gateway.zibal.ir/v1/";
    private const string MerchantId = "68f8d931ad11fa001ca7b450";

    public ZibalService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ZibalRequestResponse?> CreatePaymentAsync(long amount, string callbackUrl, string description, string orderId)
    {
        var body = new
        {
            merchant = MerchantId,
            amount,
            callbackUrl,
            description,
            orderId
        };

        var json = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var response = await _http.PostAsync($"{BaseUrl}request", json);
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ZibalRequestResponse>(content);
    }

    public async Task<ZibalVerifyResponse?> VerifyPaymentAsync(long trackId)
    {
        var body = new
        {
            merchant = MerchantId,
            trackId
        };

        var json = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var response = await _http.PostAsync($"{BaseUrl}verify", json);
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ZibalVerifyResponse>(content);
    }

    public async Task<string> InquiryAsync(long trackId)
    {
        var body = new
        {
            merchant = MerchantId,
            trackId
        };

        var json = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var response = await _http.PostAsync($"{BaseUrl}inquiry", json);
        return await response.Content.ReadAsStringAsync();
    }
}



