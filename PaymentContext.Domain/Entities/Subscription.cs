using System.Collections.Concurrent;
using System.ComponentModel.Design;

namespace PaymentContext.Domain.Entities;

public class Subscription
{
    private List<Payment> _payments;
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();

    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Active = true;
        _payments = new List<Payment>();
    }

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void Activated()
    {
        Active = true;
        LastUpdateDate = DateTime.Now;
    }
    
    public void Inactivated()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
}