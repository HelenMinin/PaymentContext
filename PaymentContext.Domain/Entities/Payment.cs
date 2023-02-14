using System.Reflection.Metadata.Ecma335;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    public Guid Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpiredDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public string Document { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }

    protected Payment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer,
        string document, string address, string email)
    {
        Number = Guid.NewGuid();
        PaidDate = paidDate;
        ExpiredDate = expiredDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;
    }
}