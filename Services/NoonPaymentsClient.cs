using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using NoonPayments.SDK.Helpers;
using NoonPayments.SDK.Interfaces;
using NoonPayments.SDK.Models.Requests;
using NoonPayments.SDK.Options;

namespace NoonPayments.SDK.Services;

public class NoonPaymentsClient : INoonPaymentsClient
{
    private readonly HttpClient _httpClient;
    private readonly NoonPaymentsOptions _options;

    public NoonPaymentsClient(HttpClient httpClient, IOptions<NoonPaymentsOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;

        var baseUrl = GetBaseUrl();
        _httpClient.BaseAddress = new Uri(baseUrl);

        var authHeader = AuthorizationHelper.GenerateAuthorizationHeader(
            _options.BusinessIdentifier,
            _options.ApplicationIdentifier,
            _options.ApplicationKey);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Key", authHeader.Split(" ")[1]);
    }

    public async Task<string> CreatePaymentAsync(CreatePaymentRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("order", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private string GetBaseUrl()
    {
        var env = _options.Environment.ToLower() == "live" ? "api" : "api-test";
        var region = _options.Region.ToString().ToLower();
        return region == "global"
            ? $"https://{env}.noonpayments.com/payment/v1/"
            : $"https://{env}.{region}.noonpayments.com/payment/v1/";
    }
}
