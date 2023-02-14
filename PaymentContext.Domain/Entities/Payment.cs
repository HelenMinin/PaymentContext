using System.Reflection.Metadata.Ecma335;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    public Guid Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpiredDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }

    protected Payment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer,
        Document document, Address address, Email email)
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