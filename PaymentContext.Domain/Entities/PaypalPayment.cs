namespace PaymentContext.Domain.Entities;

public class PaypalPayment : Payment
{
    public string TransactionCode { get; set; }

    public PaypalPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer,
        string document, string address, string email, string transactionCode) : base(paidDate, expiredDate, total,
        totalPaid, payer, document, address, email)
    {
        TransactionCode = transactionCode;
    }
}