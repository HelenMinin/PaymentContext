namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public string CardHolderNumber { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }

    public CreditCardPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer,
        string document, string address, string email, string cardHolderNumber, string cardNumber,
        string lastTransactionNumber) : base(paidDate, expiredDate, total, totalPaid, payer, document, address, email)
    {
        CardHolderNumber = cardHolderNumber;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }
}