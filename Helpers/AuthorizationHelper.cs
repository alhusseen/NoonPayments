using System.Text;

namespace NoonPayments.SDK.Helpers;

public static class AuthorizationHelper
{
    public static string GenerateAuthorizationHeader(string businessId, string appId, string appKey)
    {
        var raw = $"{businessId}.{appId}:{appKey}";
        var bytes = Encoding.UTF8.GetBytes(raw);
        return "Key " + Convert.ToBase64String(bytes);
    }
}
