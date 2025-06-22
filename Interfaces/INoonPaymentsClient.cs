using NoonPayments.SDK.Models.Requests;
using System.Threading.Tasks;

namespace NoonPayments.SDK.Interfaces;

public interface INoonPaymentsClient
{
    Task<string> CreatePaymentAsync(CreatePaymentRequest request);
}
