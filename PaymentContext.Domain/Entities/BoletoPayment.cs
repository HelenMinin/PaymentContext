namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }

    public BoletoPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer,
        string document, string address, string email, string barCode, string boletoNumber) : base(paidDate,
        expiredDate, total, totalPaid, payer, document, address, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }
}