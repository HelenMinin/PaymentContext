using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}