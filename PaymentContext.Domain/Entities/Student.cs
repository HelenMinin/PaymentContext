namespace PaymentContext.Domain.Entities;

public class Student
{
    private List<Subscription> _subscriptions;

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

    public Student(string firstName, string lastName, string document, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();
    }

    public void AddSubscription(Subscription subscription)
    {
        _subscriptions.ForEach(sub => sub.Inactivated());

        _subscriptions.Add(subscription);
    }
}