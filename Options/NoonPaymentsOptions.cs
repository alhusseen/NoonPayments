namespace NoonPayments.SDK.Options;

public class NoonPaymentsOptions
{
    public required string BusinessIdentifier { get; set; }
    public required string ApplicationIdentifier { get; set; }
    public required string ApplicationKey { get; set; }
    public required string Environment { get; set; } = "Sandbox"; // or "Live"
    public NoonRegion Region { get; set; } = NoonRegion.Global;
}
