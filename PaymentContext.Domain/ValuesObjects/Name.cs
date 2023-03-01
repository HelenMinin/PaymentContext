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

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 2, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caracteres.")
            .IsGreaterThan(LastName, 2, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(LastName, 40, "Name.LastName", "Sobrenome deve conter no máximo 40 caracteres."));
    }
}