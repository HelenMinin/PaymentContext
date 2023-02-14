namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public string CardHolderNumber { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }
}