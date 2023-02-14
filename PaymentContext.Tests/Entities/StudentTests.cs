using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Test()
    {
        var name = new Name("Aluno", "De teste");
        var documento = new Document("12345678900", EDocumentType.CPF);
        var email = new Email("AlunoDeTeste@teste.com");
        
        var student = new Student(name, documento,email );
        
    }
}