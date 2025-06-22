namespace NoonPayments.SDK.Models.Requests;

public class CreatePaymentRequest
{
    public string ApiOperation { get; set; } = "INITIATE";
    public OrderDetails Order { get; set; } = new();
    public AddressInfo Billing { get; set; } = new();
    public AddressInfo Shipping { get; set; } = new();
    public Configuration Configuration { get; set; } = new();
}

public class OrderDetails
{
    public double Amount { get; set; }
    public string Currency { get; set; } = "AED";
    public string Name { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public string Category { get; set; } = "pay";
    public string Channel { get; set; } = "web";
    public string Description { get; set; } = string.Empty;
    public List<OrderItem> Items { get; set; } = new();
    public string IpAddress { get; set; } = string.Empty;
}

public class OrderItem
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
}

public class AddressInfo
{
    public Address Address { get; set; } = new();
    public Contact Contact { get; set; } = new();
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string StateProvince { get; set; } = string.Empty;
    public string Country { get; set; } = "AE";
    public string? PostalCode { get; set; }
}

public class Contact
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string MobilePhone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class Configuration
{
    public string Locale { get; set; } = "en";
    public string PaymentAction { get; set; } = "AUTHORIZE,SALE";
    public string ReturnUrl { get; set; } = string.Empty;
}
