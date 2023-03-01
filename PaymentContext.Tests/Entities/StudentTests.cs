using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private static Name _name = new Name("Aluno", "De teste");
    private static Document _documento = new Document("12345678987", EDocumentType.CPF);
    private static Email _email = new Email("AlunoDeTeste@teste.com");
    private static Address _address = new Address("String", "String", "String", "String", 
        "String", "String");
    private static Payment _payment = new CreditCardPayment(DateTime.Now, DateTime.Now.AddDays(50), 
        500, 500, "payer", _documento, _address, _email, "String", 
        "String", "String");


    [TestMethod]
    public void SholdAddSubscrioptionWhenHadPayment()
    {
        var student = new Student(_name, _documento, _email);

        var sub = new Subscription(DateTime.Now.AddDays(10));
        sub.AddPayment(_payment);
        student.AddSubscription(sub);

        var sub2 = new Subscription(DateTime.Now.AddDays(5));
        sub2.AddPayment(_payment);
        student.AddSubscription(sub2);

        var sub3 = new Subscription(DateTime.Now.AddDays(50));
        sub3.AddPayment(_payment);
        student.AddSubscription(sub3);

        Assert.IsFalse(student.Notifications.Any());
        Assert.IsTrue(student.Subscriptions.Count(x => x.Active.Equals(true)) == 1);
        Assert.IsTrue(student.Subscriptions.Count(x => x.Active.Equals(false)) == 2);
    }

    [TestMethod]
    public void SholdNotAddSubscrioptionWhenHadNotPayment()
    {
        var student = new Student(_name, _documento, _email);

        var sub = new Subscription(DateTime.Now.AddDays(10));
        sub.AddPayment(_payment);
        student.AddSubscription(sub);

        var sub2 = new Subscription(DateTime.Now.AddDays(5));
        student.AddSubscription(sub2);

        var sub3 = new Subscription(DateTime.Now.AddDays(50));
        sub3.AddPayment(_payment);
        student.AddSubscription(sub3);


        Assert.IsTrue(student.Notifications.Any());
        Assert.AreEqual(1, student.Notifications.Count);
        Assert.AreEqual("Student.Subscription.Payments", student.Notifications.FirstOrDefault().Key);
        Assert.AreEqual("Está assinatura não possui pagamentos", student.Notifications.FirstOrDefault().Message);
        Assert.IsTrue(student.Subscriptions.Count(x => x.Active.Equals(true)) == 1);
        Assert.IsTrue(student.Subscriptions.Count(x => x.Active.Equals(false)) == 1);
    }
}