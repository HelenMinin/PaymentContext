using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Test()
    {
        var student = new Student("Aluno", "De teste", "12345678900", "AlunoDeTeste@teste.com");
        
    }
}