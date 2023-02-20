using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    public Address(string street, string number, string neighborhood, string city, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract<Notification>().Requires()
            .IsNullOrWhiteSpace(Street, "Address.Street", "A rua não pode ser vazio")
            .IsNullOrWhiteSpace(Number, "Address.Number", "Número não pode ser vazio")
            .IsNullOrWhiteSpace(City, "Address.City", "Cidade não pode ser vazia")
            .IsNullOrWhiteSpace(Country, "Address.Country", "País não pode ser vazio")
            .IsNullOrWhiteSpace(ZipCode, "Address.ZipCode", "CEP não pode ser vazio"));
    }
}