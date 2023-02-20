using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(IsDocumentValid(), "Document.Number", "Documento inválido"));
    }

    public bool IsDocumentValid()
    {
        var numbeReplace = Regex.Replace(Number, "[^0-9]", "");

        return Type switch
        {
            EDocumentType.CPF => numbeReplace.Length == 11,
            EDocumentType.CNPJ => numbeReplace.Length == 14,
            _ => false
        };
    }
}