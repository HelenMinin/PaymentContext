using System.Reflection.Metadata.Ecma335;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    public Guid Number { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string Document { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}