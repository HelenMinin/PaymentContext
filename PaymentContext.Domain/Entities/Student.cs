using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private readonly List<Subscription> _subscriptions;

    public Name Name { get; set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();
        
        AddNotifications(name, document, email);
    }

    public void AddSubscription(Subscription subscription)
    {
        if (!subscription.Payments.Any())
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(0,
                    subscription.Payments.Count,
                    "Student.Subscription.Payments", 
                    "Está assinatura não possui pagamentos"));
            return;
        }
        
        _subscriptions.ForEach(sub => sub.Inactivated());

        _subscriptions.Add(subscription);
    }
}