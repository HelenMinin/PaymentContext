using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands;

public class CreateCreditCardSubscriptionsCommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string EmailAddress { get; set; }
     
    public string CardHolderNumber { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }
    
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
}