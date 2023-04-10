using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionsCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string EmailAddress { get; set; }
    
    public string TransactionCode { get; set; }
    
    public Guid PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public string PayerEmail { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 2, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caracteres.")
            .IsGreaterThan(LastName, 2, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(LastName, 40, "Name.LastName", "Sobrenome deve conter no máximo 40 caracteres.")
            .IsEmail(EmailAddress, "Email.Address", "Email inválido")
            .IsNullOrWhiteSpace(Street, "Address.Street", "A rua não pode ser vazio")
            .IsNullOrWhiteSpace(Number, "Address.Number", "Número não pode ser vazio")
            .IsNullOrWhiteSpace(City, "Address.City", "Cidade não pode ser vazia")
            .IsNullOrWhiteSpace(Country, "Address.Country", "País não pode ser vazio")
            .IsNullOrWhiteSpace(ZipCode, "Address.ZipCode", "CEP não pode ser vazio")
        );
    }
}