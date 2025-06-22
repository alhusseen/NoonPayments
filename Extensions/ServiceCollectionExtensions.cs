using Microsoft.Extensions.DependencyInjection;
using NoonPayments.SDK.Interfaces;
using NoonPayments.SDK.Services;

namespace NoonPayments.SDK.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNoonPayments(this IServiceCollection services)
    {
        services.AddHttpClient<INoonPaymentsClient, NoonPaymentsClient>();
        return services;
    }
}
