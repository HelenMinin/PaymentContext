using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; private set; }

    public Email(string address)
    {
        Address = address;
    }
}